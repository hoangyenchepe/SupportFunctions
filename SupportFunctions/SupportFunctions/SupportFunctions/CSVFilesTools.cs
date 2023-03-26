using CsvHelper;
using SupportFunctions.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace SupportFunctions
{
    public class CSVFilesTools
    {
        public void FilterGreatestDuplicatedLine()
        {
            Console.WriteLine("Start filter greatest duplicate lines");
            var appMembers = new List<AppMember>() { };
            string[] lines = File.ReadAllLines(@"C:\Yen\Company\test3.csv");
            foreach (string line in lines)
            {
                string[] columns = line.Split(',');
                if (String.IsNullOrEmpty(columns[0]) || String.IsNullOrEmpty(columns[1]))
                {
                    continue;
                }

                var existItem = appMembers.Find(x => x.MemberId == columns[0]);
                var appMember = new AppMember();
                if (existItem == null)
                {
                    appMember.MemberId = columns[0];
                    appMember.Claims = columns[1];
                }
                else
                {
                    try
                    {
                        if (Int32.Parse(existItem.Claims) < Int32.Parse(columns[1]))
                        {
                            appMembers.Remove(existItem);
                            appMembers.Add(new AppMember { MemberId = columns[0], Claims = columns[1] });
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        continue;
                    }

                }

                if (appMember != null)
                {
                    appMembers.Add(appMember);
                }
            }

            using (var writer = new StreamWriter(@"C:\Yen\Company\test4.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(appMembers);
            }

            Console.WriteLine("End filter greatest duplicate lines");
            Console.ReadLine();
        }
    }
}
