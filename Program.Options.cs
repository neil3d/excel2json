using System;
using CommandLine;
using CommandLine.Text;

namespace excel2json
{
    partial class Program
    {
        /// <summary>
        /// 命令行参数定义
        /// </summary>
        private sealed class Options
        {
            [Option('e', "excel", Required=true, HelpText = "输入的Excel文件路径.")]
            public string ExcelPath
            {
                get;
                set;
            }

            [Option('j', "json", Required = false, HelpText = "指定输出的json文件路径.")]
            public string JsonPath
            {
                get;
                set;
            }

            [Option('s', "sql", Required = false, HelpText = "指定输出的SQL文件路径.")]
            public string SQLPath
            {
                get;
                set;
            }

            [Option('p', "csharp", Required = false, HelpText = "指定输出的C#数据定义代码文件路径.")]
            public string CSharpPath
            {
                get;
                set;
            }

            [Option('h', "header", Required = true, HelpText = "表格中有几行是表头.")]
            public int HeaderRows
            {
                get;
                set;
            }

            [Option('c', "encoding", Required = false, DefaultValue="utf8-nobom", HelpText = "指定编码的名称.")]
            public string Encoding
            {
                get;
                set;
            }

            [Option('l', "lowcase", Required = false, DefaultValue = false, HelpText = "字段名称自动转换为小写")]
            public bool Lowcase
            {
                get;
                set;
            }
        }
    }
}
