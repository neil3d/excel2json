using System;
using System.IO;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace excel2json
{
    /// <summary>
    /// 将DataTable对象，转换成JSON string，并保存到文件中
    /// </summary>
    class JsonExporter
    {
        Dictionary<string, Dictionary<string, object>> m_data;

        /// <summary>
        /// 构造函数：完成内部数据创建
        /// </summary>
        /// <param name="sheet">ExcelReader创建的一个表单</param>
        /// <param name="headerRows">表单中的那几行是表头</param>
        public JsonExporter(DataTable sheet, int headerRows)
        {
            if (sheet.Columns.Count <= 0)
                return;
            if (sheet.Rows.Count <= 0)
                return;

            m_data = new Dictionary<string, Dictionary<string, object>>();

            //--以第一列为ID，转换成ID->Object的字典
            int i = 0;
            foreach (DataRow row in sheet.Rows)
            {
                if (i >= headerRows-1)
                {
                    var rowData = new Dictionary<string, object>();
                    foreach (DataColumn column in sheet.Columns)
                    {
                        rowData[column.ToString()] = row[column];
                    }

                    string ID = row[sheet.Columns[0]].ToString();
                    m_data[ID] = rowData;
                }
                i++;
            }
        }

        /// <summary>
        /// 将内部数据转换成Json文本，并保存至文件
        /// </summary>
        /// <param name="jsonPath">输出文件路径</param>
        public void SaveJsonToFile(string jsonPath)
        {
            if (m_data == null)
                throw new Exception("JsonExporter内部数据为空。");

            string json = JsonConvert.SerializeObject(m_data, Formatting.Indented);

            using (FileStream file = new FileStream(jsonPath, FileMode.Create, FileAccess.Write))
            {
                using (TextWriter writer = new StreamWriter(file, Encoding.UTF8))
                    writer.Write(json);
            }
        }
    }
}
