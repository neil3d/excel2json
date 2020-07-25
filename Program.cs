using System;
using System.IO;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace excel2json
{
    /// <summary>
    /// 应用程序
    /// </summary>
    sealed partial class Program
    {
        /// <summary>
        /// 应用程序入口
        /// </summary>
        /// <param name="args">命令行参数</param>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                //-- GUI MODE ----------------------------------------------------------
                Console.WriteLine("Launch excel2json GUI Mode...");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new GUI.MainForm());
            }
            else
            {
                //-- COMMAND LINE MODE -------------------------------------------------

                //-- 分析命令行参数
                var options = new Options();
                var parser = new CommandLine.Parser(with => with.HelpWriter = Console.Error);

                if (parser.ParseArgumentsStrict(args, options, () => Environment.Exit(-1)))
                {
                    //-- 执行导出操作
                    try
                    {
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
                    catch (Exception exp)
                    {
                        Console.WriteLine("Error: " + exp.Message);
                    }
                }
            }// end of else
        }

        /// <summary>
        /// 根据命令行参数，执行Excel数据导出工作
        /// </summary>
        /// <param name="options">命令行参数</param>
        private static void Run(Options options)
        {

            //-- Excel File 
            string excelPath = options.ExcelPath;
            string excelName = Path.GetFileNameWithoutExtension(options.ExcelPath);

            //-- Header
            int header = options.HeaderRows;

            //-- Encoding
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

            //-- Date Format
            string dateFormat = options.DateFormat;

            //-- Export path
            string exportPath;
            if (options.JsonPath != null && options.JsonPath.Length > 0)
            {
                exportPath = options.JsonPath;
            }
            else
            {
                exportPath = Path.ChangeExtension(excelPath, ".json");
            }

            //-- Load Excel
            ExcelLoader excel = new ExcelLoader(excelPath, header);

            //-- export
            JsonExporter exporter = new JsonExporter(excel, options.Lowcase, options.ExportArray, dateFormat, options.ForceSheetName, header, options.ExcludePrefix, options.CellJson);
            exporter.SaveToFile(exportPath, cd);

            //-- 生成C#定义文件
            if (options.CSharpPath != null && options.CSharpPath.Length > 0)
            {
                CSDefineGenerator generator = new CSDefineGenerator(excelName, excel, options.ExcludePrefix);
                generator.SaveToFile(options.CSharpPath, cd);
            }
        }
    }
}
