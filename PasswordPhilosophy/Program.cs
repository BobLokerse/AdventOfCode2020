using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PasswordPhilosophy
{
    /// <summary>
    /// --- Part Two ---
    /// While it appears you validated the passwords correctly, they don't seem to be what the Official Toboggan Corporate Authentication System is expecting.
    /// The shopkeeper suddenly realizes that he just accidentally explained the password policy rules from his old job at the sled rental place down the street! The Official Toboggan Corporate Policy actually works a little differently.
    /// Each policy actually describes two positions in the password, where 1 means the first character, 2 means the second character, and so on. (Be careful; Toboggan Corporate Policies have no concept of "index zero"!) Exactly one of these positions must contain the given letter. Other occurrences of the letter are irrelevant for the purposes of policy enforcement.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string[] passwords = ReadPasswords();
            var pwPhilosophy = new PasswordPhilosophy(passwords);

            var validationMethod1 = new Func<PasswordWithSpec, bool>(pwPhilosophy.CheckPasswordOnSpecPart1);
            var validationMethod2 = new Func<PasswordWithSpec, bool>(pwPhilosophy.CheckPasswordOnSpecPart2);
            pwPhilosophy.CountNrOfValidPasswords(validationMethod2);

            PrintPasswords(pwPhilosophy.ValidPasswords);
            Console.WriteLine();
            Console.Write($"Number of valid passwords:{pwPhilosophy.NrOfValidPasswords}");
            
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
