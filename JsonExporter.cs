using System;
using System.IO;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace excel2json {
    /// <summary>
    /// 将DataTable对象，转换成JSON string，并保存到文件中
    /// </summary>
    class JsonExporter {
        string mContext = "";

        public string context {
            get {
                return mContext;
            }
        }

        /// <summary>
        /// 构造函数：完成内部数据创建
        /// </summary>
        /// <param name="sheet">ExcelReader创建的一个表单</param>
        /// <param name="headerRows">表单中的那几行是表头</param>
        public JsonExporter(DataTable sheet, int headerRows, bool lowcase, bool exportArray) {
            if (sheet.Columns.Count <= 0)
                return;
            if (sheet.Rows.Count <= 0)
                return;

            //-- 转换为JSON字符串
            if (exportArray) {
                convertArray(sheet, headerRows, lowcase);
            }
            else {
                convertDict(sheet, headerRows, lowcase);
            }
        }

        private void convertArray(DataTable sheet, int headerRows, bool lowcase) {
            List<object> values = new List<object>();

            int firstDataRow = headerRows - 1;
            for (int i = firstDataRow; i < sheet.Rows.Count; i++) {
                DataRow row = sheet.Rows[i];

                values.Add(
                    convertRowData(sheet, row, lowcase, firstDataRow)
                    );
            }

            //-- convert to json string
            mContext = JsonConvert.SerializeObject(values, Formatting.Indented);
        }

        /// <summary>
        /// 以第一列为ID，转换成ID->Object的字典对象
        /// </summary>
        private void convertDict(DataTable sheet, int headerRows, bool lowcase) {
            Dictionary<string, object> importData =
                new Dictionary<string, object>();

            int firstDataRow = headerRows - 1;
            for (int i = firstDataRow; i < sheet.Rows.Count; i++) {
                DataRow row = sheet.Rows[i];
                string ID = row[sheet.Columns[0]].ToString();
                if (ID.Length <= 0)
                    ID = string.Format("row_{0}", i);

                importData[ID] = convertRowData(sheet, row, lowcase, firstDataRow);
            }

            //-- convert to json string
            mContext = JsonConvert.SerializeObject(importData, Formatting.Indented);
        }

        /// <summary>
        /// 把一行数据转换成一个对象，每一列是一个属性
        /// </summary>
        private object convertRowData(DataTable sheet, DataRow row, bool lowcase, int firstDataRow) {
            var rowData = new Dictionary<string, object>();
            int col = 0;
            foreach (DataColumn column in sheet.Columns) {
                object value = row[column];

                if (value.GetType() == typeof(System.DBNull)) {
                    value = getColumnDefault(sheet, column, firstDataRow);
                }
                else if (value.GetType() == typeof(double)) { // 去掉数值字段的“.0”
                    double num = (double)value;
                    if ((int)num == num)
                        value = (int)num;
                }

                string fieldName = column.ToString();
                // 表头自动转换成小写
                if (lowcase)
                    fieldName = fieldName.ToLower();

                if (string.IsNullOrEmpty(fieldName))
                    fieldName = string.Format("col_{0}", col);

                rowData[fieldName] = value;
                col++;
            }

            return rowData;
        }

        /// <summary>
        /// 对于表格中的空值，找到一列中的非空值，并构造一个同类型的默认值
        /// </summary>
        private object getColumnDefault(DataTable sheet, DataColumn column, int firstDataRow) {
            for (int i = firstDataRow; i < sheet.Rows.Count; i++) {
                object value = sheet.Rows[i][column];
                Type valueType = value.GetType();
                if (valueType != typeof(System.DBNull)) {
                    if (valueType.IsValueType)
                        return Activator.CreateInstance(valueType);
                    break;
                }
            }
            return "";
        }

        /// <summary>
        /// 将内部数据转换成Json文本，并保存至文件
        /// </summary>
        /// <param name="jsonPath">输出文件路径</param>
        public void SaveToFile(string filePath, Encoding encoding) {
            //-- 保存文件
            using (FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write)) {
                using (TextWriter writer = new StreamWriter(file, encoding))
                    writer.Write(mContext);
            }
        }
    }
}
