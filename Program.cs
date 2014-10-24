using System;
using System.IO;
using System.Data;
using System.Text;
using Excel;

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
        static void Main(string[] args)
        {
            System.DateTime startTime = System.DateTime.Now;

            //-- 分析命令行参数
            var options = new Options();
            var parser = new CommandLine.Parser(with => with.HelpWriter = Console.Error);

            if (parser.ParseArgumentsStrict(args, options, () => Environment.Exit(-1)))
            {
                //-- 执行导出操作
                try
                {
                    Run(options);
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Error: " + exp.Message);
                }
            }

            //-- 程序计时
            System.DateTime endTime = System.DateTime.Now;
            System.TimeSpan dur = endTime - startTime;
            Console.WriteLine(
                string.Format("[{0}]\t=>\t[{1}]：转换完成[{2}毫秒].", 
                Path.GetFileName(options.ExcelPath),
                Path.GetFileName(options.JsonPath), 
                dur.Milliseconds)
                );
        }

        /// <summary>
        /// 根据命令行参数，执行Excel数据导出工作
        /// </summary>
        /// <param name="options">命令行参数</param>
        private static void Run(Options options)
        {
            string excelPath = options.ExcelPath;
            string jsonPath = options.JsonPath;
            int header = options.HeaderRows;

            // 加载Excel文件
            using (FileStream excelFile = File.Open(excelPath, FileMode.Open, FileAccess.Read))
            {
                // Reading from a OpenXml Excel file (2007 format; *.xlsx)
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(excelFile);

                // The result of each spreadsheet will be created in the result.Tables
                excelReader.IsFirstRowAsColumnNames = true;
                DataSet book = excelReader.AsDataSet();

                // 数据检测
                if (book.Tables.Count < 1)
                {
                    throw new Exception("Excel文件中没有找到Sheet: " + excelPath);
                }

                // 取得数据
                DataTable sheet = book.Tables[0];
                if (sheet.Rows.Count <= 0)
                {
                    throw new Exception("Excel Sheet中没有数据: " + excelPath);
                }

                //-- 确定编码
                Encoding cd = new UTF8Encoding(false);
                if (options.Encoding != "utf8-nobom")
                {
                    foreach (EncodingInfo ei in Encoding.GetEncodings())
                    {
                        Encoding e = ei.GetEncoding();
                        if (e.EncodingName == options.Encoding)
                        {
                            cd = e;
                            break;
                        }
                    }
                }

                // 导出JSON
                JsonExporter exporter = new JsonExporter(sheet, header);
                exporter.SaveJsonToFile(jsonPath, cd);
            }
        }
    }
}
