using Excel;
using System;
using System.Data;
using System.IO;
using System.Text;

namespace excel2json.GUI {

    /// <summary>
    /// 为GUI模式提供的整体数据管理
    /// </summary>
    class DataManager {
      
        // 数据导入设置
        private Program.Options mOptions;
        private Encoding mEncoding;

        // 导出数据
        private JsonExporter mJson;
        private SQLExporter mSQL;
        private CSDefineGenerator mCSharp;

        /// <summary>
        /// 导出的Json文本
        /// </summary>
        public string JsonContext {
            get {
                if (mJson != null)
                    return mJson.context;
                else
                    return "";
            }
        }

        /// <summary>
        /// 导出的SQL文本
        /// </summary>
        public string SQLContext {
            get {
                if (mSQL != null)
                    return mSQL.structSQL + mSQL.contentSQL;
                else
                    return "";
            }
        }

        /// <summary>
        /// 导出的C#代码
        /// </summary>
        public string CSharpCode {
            get {
                if (mCSharp != null)
                    return mCSharp.code;
                else
                    return "";
            }
        }

        /// <summary>
        /// 保存Json
        /// </summary>
        /// <param name="filePath">保存路径</param>
        public void saveJson(string filePath) {
            if (mJson != null) {
                mJson.SaveToFile(filePath, mEncoding);
            }
        }

        /// <summary>
        /// 保存SQL
        /// </summary>
        /// <param name="filePath">保存路径</param>
        public void saveSQL(string filePath) {
            if (mSQL != null) {
                mSQL.SaveToFile(filePath, mEncoding);
            }
        }

        /// <summary>
        /// 保存C#代码
        /// </summary>
        /// <param name="filePath">保存路径</param>
        public void saveCode(string filePath) {
            if (mCSharp != null) {
                mCSharp.SaveToFile(filePath, mEncoding);
            }
        }

        /// <summary>
        /// 加载Excel文件
        /// </summary>
        /// <param name="options">导入设置</param>
        public void loadExcel(Program.Options options) {
            mOptions = options;
            string excelPath = options.ExcelPath;
            string excelName = Path.GetFileNameWithoutExtension(excelPath);
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
                mEncoding = cd;

                //-- 导出JSON
                mJson = new JsonExporter(sheet, header, options.Lowcase, options.ExportArray);

                //-- 导出SQL
                mSQL = new SQLExporter(excelName, sheet, header);

                //-- 生成C#定义代码
                mCSharp = new CSDefineGenerator(excelName, sheet);
            }
        }
    }
}
