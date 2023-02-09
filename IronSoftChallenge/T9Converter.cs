using System;
using System.Text.RegularExpressions;

namespace IronSoftChallenge {

    public static class T9Converter {

        // A dictionary that maps a digit to a string of characters representing
        // options for that digit
        private static Dictionary<string, string> _digitToCharacterMap = new Dictionary<string, string>() {
            { "1", "&'()" },
            { "2", "abc" },
            { "3", "def" },
            { "4", "ghi" },
            { "5", "jkl" },
            { "6", "mno" },
            { "7", "pqrs" },
            { "8", "tuv" },
            { "9", "wxyz" },
            { "0", " "}
        };

        /// <summary>
        /// Given an input string of T9 characters, return the corresponding text.
        /// </summary>
        /// <param name="input">The input string, which will be checked for correctness of T9 characters </param>
        /// <returns> The QWERTY text that was represented by the T9 character input </returns>
        public static String OldPhonePad(string input) {

            // check for invalid input
            if (input.Length == 0) throw new Exception("Invalid Input, no input.");
            if (Regex.Matches(input, @"[^\d\s#\*]").Count > 0) throw new Exception("Invalid Input, invalid characters.");
            if (input[input.Length - 1] != '#') throw new Exception("Invalid Input, no # at the end.");
            if (input.IndexOf('#') < input.Length - 1) throw new Exception("Invalid Input, # must be at the end.");

            List<string> substrings = splitInputIntoSubstrings(input);
            string output = "";

            foreach (string substring in substrings) {
                string firstDigit = substring.Substring(0, 1);

                if (_digitToCharacterMap.ContainsKey(firstDigit)) {
                    // find the string of characters associated to the digit
                    // and take the correct character from the string
                    // using the remainder of the length of the substring and the
                    // length of the string of characters associated with that digit
                    string value = _digitToCharacterMap[firstDigit];
                    output += value.Substring((substring.Length - 1) % value.Length, 1);
                } else if (firstDigit == "*") {
                    // backspace, remove the last character
                    for (int count = 0; count < substring.Length; count++ ) {
                        if (output.Length > 0) output = output.Substring(0, output.Length - 1);
                    }
                }
            }

            return output;
        }

        /// <summary>
        /// Given an input string of T9 characters, return a series of substrings
        /// of grouped identical digits. Each substring represents a single
        /// character.
        /// </summary>
        /// <param name="input">The input string of T9 characters </param>
        /// <returns> A list of substrings of grouped identical digits </returns>
        private static List<string> splitInputIntoSubstrings(string input) {

            List<string> substrings = new List<string>();
            int count = 0;

            // loop through all characters of the input text, grouping together
            // similar digits, stopping matching when a different digit is found
            // (including spaces, * or #)
            while (count < input.Length) {

                int innerCount = count + 1;
                while (innerCount < input.Length && input[innerCount] == input[count]) {
                    // move the matching group size counter forward while the digits 
                    // found are the same
                    innerCount++;
                }

                // found a matching group, add it to the list of substrings
                substrings.Add(input.Substring(count, innerCount - count));

                // move the counter to the end of the matching group
                count = innerCount;
            }

            // remove any empty strings from the list 
            substrings = substrings.Where(s => !string.IsNullOrEmpty(s)).ToList();
            return substrings;
        }
    }
}
