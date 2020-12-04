using System;
using System.IO;
using System.Linq;

namespace AdventOfCode_Day1_ReportRepair
{
    public class Report
    {
        private const int Year = 2020;
        public static int? Fix(out (int? x, int? y, int? z) entries)
        {
            var lines = File.ReadAllLines(@".\input.txt");
            var list = lines.ToList();

            foreach (var entry1 in list)
            {
                var entryX = int.Parse(entry1);
                var sumY = Year - entryX;

                foreach (var entry2 in list.Skip(1))
                {
                    var entryY = int.Parse(entry2);
                    var entryZ = sumY - entryY;

                    if (list.Skip(1).Contains(entryZ.ToString()))
                    {
                        entries = (entryX, entryY, entryZ);
                        return entryX * entryY * entryZ;
                    }    
                }
            }
            
            entries = (null, null, null);
            return null; 
        }
    }
}