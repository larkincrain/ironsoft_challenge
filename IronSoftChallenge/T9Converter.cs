using System;

namespace IronSoftChallenge {

    public static class T9Converter {

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

        public static string OldPhonePad(string input) {

            // check for invalid input
            if (input[input.Length - 1] != '#') throw new Exception("Invalid Input, no # at the end");
            if (input.IndexOf('#') < input.Length - 1) throw new Exception("Invalid Input, # must be at the end");

            List<string> substrings = new List<string>();
            substrings = splitInputIntoSubstrings(input);

            string output = "";

            foreach (string substring in substrings) {
                string firstDigit = substring.Substring(0, 1);
                int lengthOfSubstring = substring.Length;

                if (_digitToCharacterMap.ContainsKey(firstDigit)) {
                    // find the string of characters associated to the digit
                    // and take the correct character from the string
                    // using the remainder of the length of the substring and the
                    // length of the string of characters
                    string value = _digitToCharacterMap[substring.Substring(0, 1)];
                    output += value.Substring((lengthOfSubstring - 1) % value.Length, 1);
                } else if (firstDigit == "*") {
                    // backspace, remove the last character
                    for (int count = 0; count < lengthOfSubstring; count++ ) {
                        if (output.Length > 0) output = output.Substring(0, output.Length - 1);
                    }
                }
            }

            return output;
        }

        private static List<string> splitInputIntoSubstrings(string input) {

            List<string> substrings = new List<string>();
            int count = 0;

            while (count < input.Length) {

                int nextCount = count + 1;
                while (nextCount < input.Length && input[nextCount] == input[count]) {
                    nextCount++;
                }

                substrings.Add(input.Substring(count, nextCount - count));
                count = nextCount;
            }

            substrings = substrings.Where(s => !string.IsNullOrEmpty(s)).ToList();
            return substrings;
        }
    }
}
