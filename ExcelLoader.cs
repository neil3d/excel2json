using System;
using System.IO;
using System.Data;
using ExcelDataReader;

namespace excel2json {
    /// <summary>
    /// 将 Excel 文件(*.xls 或者 *.xlsx)加载到内存 DataSet
    /// </summary>
    class ExcelLoader {
        private DataSet mData;

        public ExcelLoader(string filePath, int headerRow) {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read)) {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx)
                using (var reader = ExcelReaderFactory.CreateReader(stream)) {
                    // Use the AsDataSet extension method
                    // The result of each spreadsheet is in result.Tables
                    var result = reader.AsDataSet(createDataSetReadConfig(headerRow));
                    this.mData = result;
                }
            }

            if (this.Sheets.Count < 1) {
                throw new Exception("Excel file is empty: " + filePath);
            }
        }

        public DataTableCollection Sheets {
            get {
                return this.mData.Tables;
            }
        }

        private ExcelDataSetConfiguration createDataSetReadConfig(int headerRow) {
            var tableConfig = new ExcelDataTableConfiguration() {
                // Gets or sets a value indicating whether to use a row from the 
                // data as column names.
                UseHeaderRow = true,

                // Gets or sets a callback to determine which row is the header row. 
                // Only called when UseHeaderRow = true.
                ReadHeaderRow = (rowReader) => {
                    // skip header row
                    for (int i = 0; i < headerRow - 1; i++)
                        rowReader.Read();
                },
            };

            return new ExcelDataSetConfiguration() {
                // Gets or sets a value indicating whether to set the DataColumn.DataType
                // property in a second pass.
                UseColumnDataType = true,

                // Gets or sets a callback to obtain configuration options for a DataTable. 
                ConfigureDataTable = (tableReader) => { return tableConfig; },
            };
        }
    }
}
