using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel;
using System.Data;
using System.IO;

namespace excel2json.GUI {
    class DataManager {
        private JsonExporter mJson;
        private SQLExporter mSQL;
        private CSDefineGenerator mCSharp;

        public string JsonContext {
            get {
                if (mJson != null)
                    return mJson.context;
                else
                    return "";
            }
        }

        public void loadExcel(Program.Options options) {
            string excelPath = options.ExcelPath;
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
                        if (e.EncodingName == options.Encoding) {
                            cd = e;
                            break;
                        }
                    }
                }

                //-- 导出JSON
                mJson = new JsonExporter(sheet, header, options.Lowcase, options.ExportArray);

                //-- 导出SQL
                mSQL = new SQLExporter(sheet, header);

                //-- 生成C#定义代码
                string excelName = Path.GetFileName(excelPath);
                string classComment = string.Format("// Generate From {0}", excelName);
                mCSharp = new CSDefineGenerator(sheet);
            }
        }
    }
}
