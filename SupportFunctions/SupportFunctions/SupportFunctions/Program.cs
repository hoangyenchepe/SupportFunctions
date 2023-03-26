using System;

namespace SupportFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CSVFilesTools csvTools = new CSVFilesTools();
            csvTools.FilterGreatestDuplicatedLine();
            Console.ReadLine();
        }
    }
}
