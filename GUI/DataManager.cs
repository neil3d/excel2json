using System;
using System.Data;
using System.IO;
using System.Text;
using ExcelDataReader;

namespace excel2json.GUI {

    /// <summary>
    /// 为GUI模式提供的整体数据管理
    /// </summary>
    class DataManager
    {

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
        public string JsonContext
        {
            get
            {
                if (mJson != null)
                    return mJson.context;
                else
                    return "";
            }
        }

        /// <summary>
        /// 导出的SQL文本
        /// </summary>
        public string SQLContext
        {
            get
            {
                if (mSQL != null)
                    return mSQL.structSQL + mSQL.contentSQL;
                else
                    return "";
            }
        }

        /// <summary>
        /// 导出的C#代码
        /// </summary>
        public string CSharpCode
        {
            get
            {
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
        public void saveJson(string filePath)
        {
            if (mJson != null)
            {
                mJson.SaveToFile(filePath, mEncoding);
            }
        }

        /// <summary>
        /// 保存SQL
        /// </summary>
        /// <param name="filePath">保存路径</param>
        public void saveSQL(string filePath)
        {
            if (mSQL != null)
            {
                mSQL.SaveToFile(filePath, mEncoding);
            }
        }

        /// <summary>
        /// 保存C#代码
        /// </summary>
        /// <param name="filePath">保存路径</param>
        public void saveCode(string filePath)
        {
            if (mCSharp != null)
            {
                mCSharp.SaveToFile(filePath, mEncoding);
            }
        }

        /// <summary>
        /// 加载Excel文件
        /// </summary>
        /// <param name="options">导入设置</param>
        public void loadExcel(Program.Options options)
        {
            mOptions = options;
            string excelPath = options.ExcelPath;
            string excelName = Path.GetFileNameWithoutExtension(excelPath);
            int header = options.HeaderRows;

            // 加载Excel文件
            using (FileStream excelFile = File.Open(excelPath, FileMode.Open, FileAccess.Read))
            {
                // Reading from a OpenXml Excel file (2007 format; *.xlsx)
                using (var excelReader = ExcelReaderFactory.CreateReader(excelFile))
                {

                    // Reading from a OpenXml Excel file (2007 format; *.xlsx)
                    //IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(excelFile);

                    // The result of each spreadsheet will be created in the result.Tables
                    //excelReader.IsFirstRowAsColumnNames = true;
                    DataSet book = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        UseColumnDataType = true,
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            // Gets or sets a value indicating the prefix of generated column names.
                            EmptyColumnNamePrefix = "Column",

                            // Gets or sets a value indicating whether to use a row from the 
                            // data as column names.
                            UseHeaderRow = true,

                            // Gets or sets a callback to determine which row is the header row. 
                            // Only called when UseHeaderRow = true.
                            ReadHeaderRow = (rowReader) =>
                            {
                                // F.ex skip the first row and use the 2nd row as column headers:
                                //rowReader.Read();
                            },

                            // Gets or sets a callback to determine whether to include the 
                            // current row in the DataTable.
                            FilterRow = (rowReader) =>
                            {
                                return true;
                            },

                            // Gets or sets a callback to determine whether to include the specific
                            // column in the DataTable. Called once per column after reading the 
                            // headers.
                            FilterColumn = (rowReader, columnIndex) =>
                            {
                                return true;
                            }
                        }
                    });
                    // 数据检测
                    if (book.Tables.Count < 1)
                    {
                        throw new Exception("Excel file is empty: " + excelPath);
                    }

                    // 取得数据
                    DataTable sheet = book.Tables[0];
                    if (sheet.Rows.Count <= 0)
                    {
                        throw new Exception("Excel Sheet is empty: " + excelPath);
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
                    if (options.JsonPath != null && options.JsonPath.Length > 0)
                    {
                        JsonExporter exporter = new JsonExporter(sheet, header, options.Lowcase, options.ExportArray);
                        exporter.SaveToFile(options.JsonPath, cd);
                    }

                    //-- 导出SQL文件
                    if (options.SQLPath != null && options.SQLPath.Length > 0)
                    {
                        SQLExporter exporter = new SQLExporter(excelName, sheet, header);
                        exporter.SaveToFile(options.SQLPath, cd);
                    }

                    //-- 生成C#定义文件
                    if (options.CSharpPath != null && options.CSharpPath.Length > 0)
                    {
                        CSDefineGenerator exporter = new CSDefineGenerator(excelName, sheet);
                        exporter.SaveToFile(options.CSharpPath, cd);
                    }
            }
        }
    }
    }
}
