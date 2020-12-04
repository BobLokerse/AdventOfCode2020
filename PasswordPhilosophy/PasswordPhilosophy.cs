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
        public void CountNrOfValidPasswords()
        {
            // TODO rewrite rom dictionay to "keyValue pair list" - spec might not be unique
            //var dictionary = _passwords
            //    .Select((value, index) => new {Key = index, Value = value})
            //    .ToDictionary(keyValue => keyValue.Key, o => o.Value);

            var pwSplitUp = _passwords.Select(SplitUp);

            ValidPasswords = new List<PasswordWithSpec>();
            foreach (var passwordWithSpec in pwSplitUp)
            {
                var isValid = CheckPasswordOnSpec(passwordWithSpec);
                if (isValid)
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
                    Min = int.Parse(occ[0]),
                    Max = int.Parse(occ[1])
                }
            };
            return pwSpec;
        }

        private  bool CheckPasswordOnSpec(PasswordWithSpec passwordWithSpec)
        {
            var nrOfOccurances = passwordWithSpec.Password.Count(c => c == passwordWithSpec.Spec.Character);
            return nrOfOccurances >= passwordWithSpec.Spec.Min && nrOfOccurances <= passwordWithSpec.Spec.Max;
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
        public int Min { get; set; }
        public int Max { get; set; }

        /// <summary>Returns the fully qualified type name of this instance.</summary>
        /// <returns>The fully qualified type name.</returns>
        public override string ToString()
        {
            return $"{Min}-{Max} {Character}";
        }
    }
}
