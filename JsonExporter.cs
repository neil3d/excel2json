using System;
using System.IO;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using System.Numerics;

namespace excel2json
{
    /// <summary>
    /// 将DataTable对象，转换成JSON string，并保存到文件中
    /// </summary>
    class JsonExporter
    {
        string mContext = "";

        public string context
        {
            get { return mContext; }
        }

        private int _endColumn; //结束列，回避空列

        private Dictionary<DataColumn, FliterColumn> _typeDict = new Dictionary<DataColumn, FliterColumn>();
        // delegate string[] ConverteArray(FliterColumn fc, string s);

        /// <summary>
        /// 构造函数：完成内部数据创建
        /// </summary>
        /// <param name="sheet">ExcelReader创建的一个表单</param>
        /// <param name="headerRows">表单中的那几行是表头</param>
        public JsonExporter(DataTable sheet, int headerRows, bool lowcase, bool exportArray)
        {
            if (sheet.Columns.Count <= 0)
                return;
            if (sheet.Rows.Count <= 0)
                return;

            DataRow firstRow = sheet.Rows[0]; //列名
            DataRow typeRow = sheet.Rows[1]; //类型
            DataRow slice = sheet.Rows[2]; //数组切分符
            DataRow description = sheet.Rows[3]; //列的中文描述
            foreach (DataColumn column in sheet.Columns)
            {
                object value = firstRow[column];
                if (value is DBNull)
                {
                    break;
                }

                if (!(typeRow[column] is string thisType))
                {
                    Console.WriteLine($@"{sheet.TableName}的{firstRow[column]}字段类型为空，位于: 行 {1} ，列{_endColumn}");
                    return;
                }

                var columnFliter = new FliterColumn(description[column].ToString(), firstRow[column].ToString(),
                    thisType, default(char));
                if (thisType.StartsWith("[]"))
                {
                    columnFliter.ColumnType = columnFliter.ColumnType.Replace("[]", null);
                    try
                    {
                        var sp = JsonConvert.DeserializeAnonymousType("{" + slice[column] + "}",
                            new {ListSpliter = default(char)});
                        columnFliter.SplitChar = sp.ListSpliter;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine($@"数组类型分隔符定义错误,{sheet.TableName}的{slice[column]}，位于: 行 {0} ，列{_endColumn}");
                        return;
                    }
                }

                try
                {
                    _typeDict.Add(column, columnFliter);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($@"重复的键名,{sheet.TableName}的{firstRow[column]}，位于: 行 {0} ，列{_endColumn}");
                    return;
                }

                _endColumn++;
            }

            //-- 转换为JSON字符串
            if (exportArray)
            {
                convertArray(sheet, headerRows, lowcase);
            }
            else
            {
                ConvertDict(sheet, headerRows, lowcase);
            }
        }

        private void convertArray(DataTable sheet, int headerRows, bool lowcase)
        {
            List<object> values = new List<object>();

            int firstDataRow = headerRows;
            for (int i = firstDataRow; i < sheet.Rows.Count; i++)
            {
                DataRow row = sheet.Rows[i];
                ValueTuple<object, Error> vt = ConvertRowData(sheet, row, lowcase);
                if (vt.Item2 != null)
                {
                    Console.WriteLine(string.Format(vt.Item2.Description, i));
                }

                values.Add(vt.Item1);
            }

            //-- convert to json string
            mContext = JsonConvert.SerializeObject(values, Formatting.Indented);
        }

        /// <summary>
        /// 以第一列为ID，转换成ID->Object的字典对象
        /// </summary>
        private void ConvertDict(DataTable sheet, int headerRows, bool lowcase)
        {
            Dictionary<string, object> importData =
                new Dictionary<string, object>();

            int firstDataRow = headerRows - 1;
            for (int i = firstDataRow; i < sheet.Rows.Count; i++)
            {
                DataRow row = sheet.Rows[i];
                string id = row[sheet.Columns[0]].ToString();
                if (id.Length <= 0)
                    id = $"row_{i}";
                var vt = ConvertRowData(sheet, row, lowcase);
                if (vt.Item2 != null)
                {
                    Console.WriteLine(string.Format(vt.Item2.Description, i));
                    return;
                }

                importData[id] = vt.Item1;
            }

            //-- convert to json string
            mContext = JsonConvert.SerializeObject(importData, Formatting.Indented);
        }

        /// <summary>
        /// 把一行数据转换成一个对象，每一列是一个属性
        /// </summary>
        private (object, Error) ConvertRowData(DataTable sheet, DataRow row, bool lowcase)
        {
            Dictionary<string, object> rowData = new Dictionary<string, object>();

            DataRow typeRow = sheet.Rows[1];

            object CheekArray<T>(FliterColumn fc, string cellValue)
            {
                var cv = cellValue.Split(fc.SplitChar);
                List<T> resutList = new List<T>();
                for (int i = cv.Length - 1; i >= 0; i--)
                {
                    resutList.Add((T) Convert.ChangeType(cv[i], typeof(T)));
                }

                return resutList;
            }

            int col = 0;
            foreach (DataColumn column in sheet.Columns)
            {
                object value = row[column];
                var errorReturn = new ValueTuple<object, Error>(null,
                    new Error()
                    {
                        Description = $"{sheet.TableName}类型错误,Cell值：{value},位于 行：{{0}},列 {col}",
                        ErrorCode = 1001
                    });
                FliterColumn fcRead = _typeDict[column];

                if (col >= _endColumn)
                {
                    break;
                }

                if (value is System.DBNull)
                {
                    return errorReturn;
                }

                string fieldName = fcRead.ColumnName;
                // 表头自动转换成小写
                if (lowcase)
                    fieldName = fieldName.ToLower();

                if (string.IsNullOrEmpty(fieldName))
                    fieldName = $"col_{col}";

                bool isSlice = fcRead.SplitChar != default(char);
                switch (fcRead.ColumnType)
                {
                    case "int32":
                    case "int64":
                        if (isSlice)
                        {
                            rowData[fieldName] = CheekArray<long>(_typeDict[column], value as string);
                            break;
                        }

                        if (!long.TryParse(value.ToString(), out var longValue))
                        {
                            return errorReturn;
                        }

                        rowData[fieldName] = longValue;
                        break;
                    case "string":
                        if (isSlice)
                        {
                            rowData[fieldName] = CheekArray<string>(_typeDict[column], value as string);
                            break;
                        }

                        if (value == null) return errorReturn;
                        rowData[fieldName] = value.ToString();
                        break;
                    case "float":
                    case "double":
                        if (isSlice)
                        {
                            rowData[fieldName] = CheekArray<double>(_typeDict[column], value as string);
                            break;
                        }

                        if (!double.TryParse(value.ToString(), out var doubleValue))
                        {
                            return errorReturn;
                        }

                        rowData[fieldName] = doubleValue;
                        break;
                    case "bigint":
                        if (isSlice)
                        {
                            var bigIntArray = CheekArray<string>(_typeDict[column], value as string) as List<string>;
                            if (bigIntArray != null)
                                try
                                {
                                    for (int i = 0; i < bigIntArray.Count; i++)
                                    {
                                        bigIntArray[i] = BigInteger.Parse(bigIntArray[i], NumberStyles.Float)
                                            .ToString();
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                    return errorReturn;
                                }

                            rowData[fieldName] = bigIntArray;
                        }

                        rowData[fieldName] = BigInteger.Parse(value.ToString(), NumberStyles.Float).ToString();
                        break;
                }

                col++;
            }

            return new ValueTuple<object, Error>(rowData, null);
        }

        /// <summary>
        /// 将内部数据转换成Json文本，并保存至文件
        /// </summary>
        /// <param name="filePath">输出文件路径</param>
        public void SaveToFile(string filePath, Encoding encoding)
        {
            //-- 保存文件
            using (FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                using (TextWriter writer = new StreamWriter(file, encoding))
                    writer.Write(mContext);
            }
        }

        private class Error
        {
            public string Description;
            public int ErrorCode;
        }

        private class FliterColumn
        {
            public string ColumnName;
            public string ColumnDescrption;
            public string ColumnType;
            public char SplitChar;

            public FliterColumn(string columnDescrption, string columnName, string columnType, char splitChar)
            {
                ColumnDescrption = columnDescrption;
                ColumnName = columnName;
                ColumnType = columnType;
                SplitChar = splitChar;
            }
        }
    }
}