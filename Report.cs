using System;
using System.IO;
using System.Linq;

namespace AdventOfCode_Day1_ReportRepair
{
    public class Report
    {
        private const int Year = 2020;
        public static int? Fix()
        {
            var lines = File.ReadAllLines(@".\input.txt");
            var list = lines.ToList();

            foreach (var entry in list)
            {
                var entryX = int.Parse(entry);
                var entryY = Year - entryX;

                if (list.Contains(entryY.ToString()))
                {
                    Console.WriteLine($"EntryX:{entryX}, EntryY:{entryY}");
                    return entryX * entryY;
                }
            }
            
            return null; // 1007104
        }
    }
}