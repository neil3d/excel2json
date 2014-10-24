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

            [Option('j', "json", Required = true, HelpText = "指定输出的json文件路径.")]
            public string JsonPath
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
        }
    }
}
