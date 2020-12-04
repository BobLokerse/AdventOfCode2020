using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PasswordPhilosophy
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] passwords = ReadPasswords();
            var pwPhilosophy = new PasswordPhilosophy(passwords);
            pwPhilosophy.CountNrOfValidPasswords();

            Console.Write($"Number of valid passwords:{pwPhilosophy.NrOfValidPasswords}");
            
            PrintPasswords(pwPhilosophy.ValidPasswords);

            Console.WriteLine();
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        private static void PrintPasswords(List<PasswordWithSpec> passwords)
        {
            Console.WriteLine();

            var sb = new StringBuilder();
            foreach (var passwordWithSpec in passwords)
            {
                sb.AppendLine(passwordWithSpec.ToString());
            }

            Console.WriteLine(sb.ToString());
        }

        private static string[] ReadPasswords()
        {
            return File.ReadAllLines(@".\input.txt");
        }
    }
}
