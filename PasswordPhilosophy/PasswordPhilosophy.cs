using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordPhilosophy
{
    public class PasswordPhilosophy
    {
        private readonly string[] _passwords;
        public List<PasswordWithSpec> ValidPasswords { get; private set; }
        public int NrOfValidPasswords => ValidPasswords.Count;

        public PasswordPhilosophy(string[] passwords)
        {
            _passwords = passwords;
        }

        /// <summary>
        /// Counts the number of valid passwords, according to the specs.
        /// The valid passwords are stored in <see cref="ValidPasswords"/>.
        /// The count in 
        /// </summary>
        /// <param name="validationMethod"></param>
        public void CountNrOfValidPasswords(Func<PasswordWithSpec, bool> validationMethod)
        {
            var pwSplitUp = _passwords.Select(SplitUp);

            ValidPasswords = new List<PasswordWithSpec>();
            foreach (var passwordWithSpec in pwSplitUp)
            {
                if (validationMethod(passwordWithSpec))
                {
                    ValidPasswords.Add(passwordWithSpec);
                }
            }
        }

        private PasswordWithSpec SplitUp(string line)
        {
            var pwWithSpec = line.Split(':');
            
            var specSplit = pwWithSpec[0].Split(' ');
            var occ = specSplit[0].Split('-');

            var pwSpec = new PasswordWithSpec
            {
                Password = pwWithSpec[1].Trim(),
                Spec = new Spec
                {
                    Character = specSplit[1].First(),
                    First = int.Parse(occ[0]),
                    Second = int.Parse(occ[1])
                }
            };
            return pwSpec;
        }

        internal bool CheckPasswordOnSpecPart1(PasswordWithSpec passwordWithSpec)
        {
            var nrOfOccurances = passwordWithSpec.Password.Count(c => c == passwordWithSpec.Spec.Character);
            return nrOfOccurances >= passwordWithSpec.Spec.First && nrOfOccurances <= passwordWithSpec.Spec.Second;
        }

        /// <summary>
        /// Each policy actually describes two positions in the password,
        /// where 1 means the first character, 2 means the second character, and so on.
        /// (Be careful; Toboggan Corporate Policies have no concept of "index zero"!)
        /// Exactly one of these positions must contain the given letter.
        /// Other occurrences of the letter are irrelevant for the purposes of policy enforcement.
        /// </summary>
        /// <param name="passwordWithSpec"></param>
        /// <returns></returns>
        internal bool CheckPasswordOnSpecPart2(PasswordWithSpec passwordWithSpec)
        {
            var charToCheck = passwordWithSpec.Spec.Character;
            var firstPosZeroBased = passwordWithSpec.Spec.First - 1;
            var secondPosZeroBased = passwordWithSpec.Spec.Second - 1;

            var checkFirstChar = passwordWithSpec.Password[firstPosZeroBased] == charToCheck;
            var checkSecondChar = passwordWithSpec.Password[secondPosZeroBased] == charToCheck;
            var xor = checkFirstChar ^ checkSecondChar;
            return xor;
        }
    }

    public class PasswordWithSpec
    {
        public string Password { get; internal set; }
        public Spec Spec { get; internal set; }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{Spec.ToString()}: {Password}";
        }
    }

    public struct Spec
    {
        public char Character { get; set; }
        public int First { get; set; }
        public int Second { get; set; }

        /// <summary>Returns the fully qualified type name of this instance.</summary>
        /// <returns>The fully qualified type name.</returns>
        public override string ToString()
        {
            return $"{First}-{Second} {Character}";
        }
    }
}
