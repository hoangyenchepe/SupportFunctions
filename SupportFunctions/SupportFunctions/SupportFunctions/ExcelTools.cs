using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SupportFunctions
{
    public class ExcelTools
    {
        public void Read()
        {
            var filePaths = @"D:\data\Redeemption_SFMC_V2.xlsx";
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\nReading the Excel File...");
            Console.BackgroundColor = ConsoleColor.Black;
            Application xlApp = new Application();
            Workbook xlWorkBook = xlApp.Workbooks.Open(filePaths);
            Worksheet xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);

            Range xlRange = xlWorkSheet.UsedRange;
            int totalRows = xlRange.Rows.Count;
            int totalColumns = xlRange.Columns.Count;
            string firstValue, secondValue;
            for (int rowCount = 1; rowCount <= totalRows; rowCount++)
            {

                firstValue = Convert.ToString((xlRange.Cells[rowCount, 1] as Range).Text);
                secondValue = Convert.ToString((xlRange.Cells[rowCount, 2] as Range).Text);

                Console.WriteLine(firstValue + "\t" + secondValue);

            }

            xlWorkBook.Close();
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

            Console.WriteLine("End of the file...");
        }
    }
}
