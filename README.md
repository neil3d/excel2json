excel2json
==========

把Excel表单转换成json对象，并保存到一个文本文件中。

Project Setup
-------------
  - 导入CommandLine库：Install-Package CommandLineArgumentsParser
  - 导入ExcelReader库：Install-Package ExcelDataReader

Excel表单格式约定
-----------------
  - 第一行json字段名称；
  - 读取Excel Workbook中的第一个sheet；

命令行参数
---------
