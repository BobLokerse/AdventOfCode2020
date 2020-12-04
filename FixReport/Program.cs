using System;

namespace AdventOfCode_Day1_ReportRepair
{
    /// <summary>
    /// --- Day 1: Report Repair ---
    /// Before you leave, the Elves in accounting just need you to fix your expense report (your puzzle input); apparently, something isn't quite adding up.
    /// Specifically, they need you to find the two entries that sum to 2020 and then multiply those two numbers together.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Report repair");
            Console.WriteLine();

            var answer = Report.Fix(out var entries);

            Console.WriteLine($"EntryX:{entries.x}, EntryY:{entries.y}, EntryZ:{entries.z}");
            Console.WriteLine($"Sum:{entries.x + entries.y + entries.z}" );
            Console.WriteLine($"Answer (multiplied):{answer}");

            Console.WriteLine();
            Console.WriteLine("Press any key.");
            Console.ReadKey();
        }
    }
}
