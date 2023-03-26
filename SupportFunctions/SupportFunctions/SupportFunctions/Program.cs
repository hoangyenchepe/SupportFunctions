using System;

namespace SupportFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ExcelTools excelTools = new ExcelTools();
            excelTools.Read();
            Console.ReadLine();
        }
    }
}
