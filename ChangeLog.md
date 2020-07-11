# excel2json Change Log

## TODO

* 过滤规则：仅包含或者排除带有指定前缀的表单或者列
    * exclude_prefix
    * 典型应用：
        * Excel中包含服务端、客户端通用数据，以及各自不用的数据
        * 则可以把列命名为：client_AAA, server_BBB，输出时，可以通过这个前缀做数据过滤

## Ver 1.3.0

* 把 C# 结构体定义的功能加回来了
* 升级底层依赖库

## Ver 1.2.0

* 注意：必须先关闭 Excel 软件，再执行转换。因为 Excel 软件会锁定文件，导致其他程序无法读取
* 升级 ExcelDataReader 组件，现在支持所有 Excel 文件格式（ 2003 *.xls, 2007 *.xlsx）
* 默认导出表中所有Sheet，格式为：{ SheetName: { SheetOBject } }
* 在行对象中添加ID字段
* 去除 SQL 和 C# 结构体代码生成功能

## Ver 1.1.1

* GUI模式：增加了 [Reimport] 按钮，在设置项改变之后，方便重新导入数据；
* 优化了 Json 数组导出代码；
* 表格中空白项目计算了默认值：取当前列中非空的值，按照其类型构造默认值；



