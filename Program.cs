using System;
using System.IO;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ExcelDataReader;

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
            //if (args.Length <= 0) {
            if(false){
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
                            $@"[{Path.GetFileName(options.ExcelPath)}]：	Conversion complete in [{dur.TotalMilliseconds}ms]."
                        );
                    }
                    catch (Exception exp) {
                        Console.WriteLine("Error: " + exp.Message);
                    }
                }
                Console.WriteLine(@"json 文件生成完毕");
                Console.ReadKey();
            }// end of else
        }

        /// <summary>
        /// 根据命令行参数，执行Excel数据导出工作
        /// </summary>
        /// <param name="options">命令行参数</param>
        private static void Run(Options options) {
            DirectoryInfo theFolder = new DirectoryInfo(options.ExcelPath);
            foreach(FileInfo NextFile in theFolder.GetFiles()){
                
                if (Regex.IsMatch(NextFile.FullName,@"^.*?\.(xls|xlsx|csv)$")){
                    
                    string excelPath =NextFile.FullName;
                    string excelName = Path.GetFileNameWithoutExtension(excelPath);
                    int header = options.HeaderRows;

                    using (FileStream excelFile = File.Open(excelPath, FileMode.Open, FileAccess.Read))
                    {
                        using (var excelReader = ExcelReaderFactory.CreateReader(excelFile))
                        {
                            // Reading from a OpenXml Excel file (2007 format; *.xlsx)
                            //IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(excelFile);
                            DataSet book = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                UseColumnDataType = true,
                                ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                                {
                                    // Gets or sets a value indicating the prefix of generated column names.
                                    EmptyColumnNamePrefix = "Column",

                                    // Gets or sets a value indicating whether to use a row from the 
                                    // data as column names.
                                    UseHeaderRow = false,

                                    // Gets or sets a callback to determine which row is the header row. 
                                    // Only called when UseHeaderRow = true.
                                    ReadHeaderRow = (rowReader) =>
                                    {
                                        // F.ex skip the first row and use the 2nd row as column headers:
                                        //rowReader.Read();
                                    },

                                    // Gets or sets a callback to determine whether to include the 
                                    // current row in the DataTable.
                                    FilterRow = (rowReader) => true,

                                    // Gets or sets a callback to determine whether to include the specific
                                    // column in the DataTable. Called once per column after reading the 
                                    // headers.
                                    FilterColumn = (rowReader, columnIndex) =>
                                    {
                                        if (rowReader.FieldCount < columnIndex)
                                        { return false; }
                                        return true;
                                    }
                                }
                            });

                            // 数据检测
                            if (book.Tables.Count < 1)
                            {
                                throw new Exception("Excel file is empty: " + excelPath);
                            }

                            for (int i = 0; i < book.Tables.Count; i++)
                            {
                                // 取得数据
                                DataTable sheet = book.Tables[i];
                                if (sheet.Rows.Count <= 0)
                                {
                                    throw new Exception("Excel Sheet is empty: " + excelPath);
                                }

                                if (sheet.TableName.StartsWith("#"))//sheet头加#的不读
                                {
                                    continue;
                                }
                                //-- 确定编码
                                Encoding cd = new UTF8Encoding(false);
                                if (options.Encoding != "utf8-nobom")
                                {
                                    foreach (EncodingInfo ei in Encoding.GetEncodings())
                                    {
                                        Encoding e = ei.GetEncoding();
                                        if (e.HeaderName == options.Encoding)
                                        {
                                            cd = e;
                                            break;
                                        }
                                    }
                                }

                                //-- 导出JSON文件
                                //if (options.JsonPath != null && options.JsonPath.Length > 0) {
                                JsonExporter exporter = new JsonExporter(sheet, header, options.Lowcase, options.ExportArray);
                                exporter.SaveToFile(options.JsonPath + "/" + sheet.TableName + ".json", cd);
                            }
                            //}
                            /*
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
                            */
                        }
                    }// 加载Excel文件
                }
            }

        }
    }
}
