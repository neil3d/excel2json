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

            Dictionary<string, Dictionary<string, object>> importData;
            importData = new Dictionary<string, Dictionary<string, object>>();

            //--以第一列为ID，转换成ID->Object的字典
            int firstDataRow = headerRows - 1;
            for (int i = firstDataRow; i < sheet.Rows.Count; i++) {
                DataRow row = sheet.Rows[i];
                string ID = row[sheet.Columns[0]].ToString();
                if (ID.Length <= 0)
                    continue;

                var rowData = new Dictionary<string, object>();
                foreach (DataColumn column in sheet.Columns) {
                    object value = row[column];
                    // 去掉数值字段的“.0”
                    if (value.GetType() == typeof(double)) {
                        double num = (double)value;
                        if ((int)num == num)
                            value = (int)num;
                    }
                    string fieldName = column.ToString();
                    // 表头自动转换成小写
                    if (lowcase)
                        fieldName = fieldName.ToLower();

                    if (!string.IsNullOrEmpty(fieldName))
                        rowData[fieldName] = value;
                }

                importData[ID] = rowData;
            }

            //-- 转换为JSON字符串
            if (exportArray) {
                List<object> values = new List<object>();
                foreach (var obj in importData.Values)
                    values.Add(obj);
                mContext = JsonConvert.SerializeObject(values, Formatting.Indented);
            }
            else {
                mContext = JsonConvert.SerializeObject(importData, Formatting.Indented);
            }
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
