using System;
using System.IO;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Excel;

namespace excel2json {
    /// <summary>
    /// 应用程序
    /// </summary>
    sealed partial class Program {
        /// <summary>
        /// 应用程序入口
        /// </summary>
        /// <param name="args">命令行参数</param>
        [STAThread]
        static void Main(string[] args) {
            if (args.Length <= 0) {
                //-- GUI MODE ----------------------------------------------------------
                Console.WriteLine("Launch excel2json GUI Mode...");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new GUI.MainForm());
            }
            else {
                //-- COMMAND LINE MODE -------------------------------------------------
                
                //-- 分析命令行参数
                var options = new Options();
                var parser = new CommandLine.Parser(with => with.HelpWriter = Console.Error);

                if (parser.ParseArgumentsStrict(args, options, () => Environment.Exit(-1))) {
                    //-- 执行导出操作
                    try {
                        DateTime startTime = DateTime.Now;
                        Run(options);
                        //-- 程序计时
                        DateTime endTime = DateTime.Now;
                        TimeSpan dur = endTime - startTime;
                        Console.WriteLine(
                            string.Format("[{0}]：\tConversion complete in [{1}ms].",
                            Path.GetFileName(options.ExcelPath),
                            dur.TotalMilliseconds)
                            );
                    }
                    catch (Exception exp) {
                        Console.WriteLine("Error: " + exp.Message);
                    }
                }
            }// end of else
        }

        /// <summary>
        /// 根据命令行参数，执行Excel数据导出工作
        /// </summary>
        /// <param name="options">命令行参数</param>
        private static void Run(Options options) {
            string excelPath = options.ExcelPath;
            string excelName = Path.GetFileNameWithoutExtension(options.ExcelPath);
            int header = options.HeaderRows;

            // 加载Excel文件
            using (FileStream excelFile = File.Open(excelPath, FileMode.Open, FileAccess.Read)) {
                // Reading from a OpenXml Excel file (2007 format; *.xlsx)
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(excelFile);

                // The result of each spreadsheet will be created in the result.Tables
                excelReader.IsFirstRowAsColumnNames = true;
                DataSet book = excelReader.AsDataSet();

                // 数据检测
                if (book.Tables.Count < 1) {
                    throw new Exception("Excel file is empty: " + excelPath);
                }

                // 取得数据
                DataTable sheet = book.Tables[0];
                if (sheet.Rows.Count <= 0) {
                    throw new Exception("Excel Sheet is empty: " + excelPath);
                }

                //-- 确定编码
                Encoding cd = new UTF8Encoding(false);
                if (options.Encoding != "utf8-nobom") {
                    foreach (EncodingInfo ei in Encoding.GetEncodings()) {
                        Encoding e = ei.GetEncoding();
                        if (e.HeaderName == options.Encoding) {
                            cd = e;
                            break;
                        }
                    }
                }

                //-- 导出JSON文件
                if (options.JsonPath != null && options.JsonPath.Length > 0) {
                    JsonExporter exporter = new JsonExporter(sheet, header, options.Lowcase, options.ExportArray);
                    exporter.SaveToFile(options.JsonPath, cd);
                }

                //-- 导出SQL文件
                if (options.SQLPath != null && options.SQLPath.Length > 0) {
                    SQLExporter exporter = new SQLExporter(excelName, sheet, header);
                    exporter.SaveToFile(options.SQLPath, cd);
                }

                //-- 生成C#定义文件
                if (options.CSharpPath != null && options.CSharpPath.Length > 0) {
                    CSDefineGenerator exporter = new CSDefineGenerator(excelName, sheet);
                    exporter.SaveToFile(options.CSharpPath, cd);
                }
            }
        }
    }
}
