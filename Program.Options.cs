using System;
using CommandLine;
using CommandLine.Text;

namespace excel2json {
    partial class Program {
        /// <summary>
        /// 命令行参数定义
        /// </summary>
        internal sealed class Options {
            public Options() {
                this.HeaderRows = 3;
                this.Encoding = "utf8-nobom";
                this.Lowcase = false;
                this.ExportArray = false;
            }

            [Option('e', "excel", Required = true, HelpText = "input excel file path.")]
            public string ExcelPath {
                get;
                set;
            }

            [Option('j', "json", Required = false, HelpText = "export json file path.")]
            public string JsonPath {
                get;
                set;
            }

            [Option('s', "sql", Required = false, HelpText = "export SQL file path.")]
            public string SQLPath {
                get;
                set;
            }

            [Option('p', "csharp", Required = false, HelpText = "export C# data struct code file path.")]
            public string CSharpPath {
                get;
                set;
            }

            [Option('h', "header", Required = true, HelpText = "number lines in sheet as header.")]
            public int HeaderRows {
                get;
                set;
            }

            [Option('c', "encoding", Required = false, DefaultValue = "utf8-nobom", HelpText = "export file encoding.")]
            public string Encoding {
                get;
                set;
            }

            [Option('l', "lowcase", Required = false, DefaultValue = false, HelpText = "convert filed name to lowcase.")]
            public bool Lowcase {
                get;
                set;
            }

            [Option('a', "array", Required = false, DefaultValue = false, HelpText = "export as array, otherwise as dict object.")]
            public bool ExportArray {
                get;
                set;
            }
        }
    }
}
