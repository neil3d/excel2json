using System;
using System.IO;
using System.Data;
using System.Text;
using System.Collections.Generic;

namespace excel2json
{
    /// <summary>
    /// 根据表头，生成C#类定义数据结构
    /// 表头使用三行定义：字段名称、字段类型、注释
    /// </summary>
    class CSDefineGenerator
    {
        struct FieldDef
        {
            public string name;
            public string type;
            public string comment;
        }

        string mCode;

        public string code {
            get {
                return this.mCode;
            }
        }

        public CSDefineGenerator(string excelName, ExcelLoader excel)
        {
            //-- 创建代码字符串
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("//");
            sb.AppendLine("// Auto Generated Code By excel2json");
            sb.AppendLine("// https://neil3d.gitee.io/coding/excel2json.html");
            sb.AppendLine("// 1. 每个 Sheet 形成一个 Struct 定义, Sheet 的名称作为 Struct 的名称");
            sb.AppendLine("// 2. 表格约定：第一行是变量名称，第二行是变量类型");
            sb.AppendLine();
            sb.AppendFormat("// Generate From {0}.xlsx", excelName);
            sb.AppendLine();
            sb.AppendLine();

            for (int i = 0; i < excel.Sheets.Count; i++)
            {
                DataTable sheet = excel.Sheets[i];
                sb.Append(_exportSheet(sheet));
            }

            sb.AppendLine();
            sb.AppendLine("// End of Auto Generated Code");

            mCode = sb.ToString();
        }

        private string _exportSheet(DataTable sheet)
        {
            if (sheet.Columns.Count < 0 || sheet.Rows.Count < 2)
                return "";

            // get field list
            List<FieldDef> fieldList = new List<FieldDef>();
            DataRow typeRow = sheet.Rows[0];
            DataRow commentRow = sheet.Rows[1];

            foreach (DataColumn column in sheet.Columns)
            {
                FieldDef field;
                field.name = column.ToString();
                field.type = typeRow[column].ToString();
                field.comment = commentRow[column].ToString();

                fieldList.Add(field);
            }

            // export as string
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("public class {0}\r\n{{", sheet.TableName);
            sb.AppendLine();

            foreach (FieldDef field in fieldList)
            {
                sb.AppendFormat("\tpublic {0} {1}; // {2}", field.type, field.name, field.comment);
                sb.AppendLine();
            }

            sb.Append('}');
            sb.AppendLine();
            sb.AppendLine();
            return sb.ToString();
        }

        public void SaveToFile(string filePath, Encoding encoding)
        {
            //-- 保存文件
            using (FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                using (TextWriter writer = new StreamWriter(file, encoding))
                    writer.Write(mCode);
            }
        }
    }
}
