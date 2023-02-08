# IronSoft Programming Challenge
C# Programming Challenge for IronSoft

To run the software, please use the following command within the ```\IronSoftChallenge``` directory: ```dotnet run```.

You'll be prompted to enter a string contains digits spaces and a hash symbol. Once you've pressed return, the output will be displayed to you.

## Notes on Design
The idea is to convert a series of digits, spaces and a hash symbol into alpha characters using the T9 pattern. 

I've implemented a dictionary that maps each digit to a string containing the 3 or 4 characters that are possible to be represented by this digit, depending on how many times this digit occurs sequentially within the input.

To determine which characters should be output given an input string, the following rules are applied:

* Split into a list of substrings composed of similar, sequential digits 
* Trim each substring to remove leading or trailing spaces
* For each substring (which now is composed of a number of identical characters)
    * Check if the dictionary contains a mapping for the digit in question
    * If the dictionary contains a lookup, find the index of the character to add to our output string by taking the remainder of the length of the input substring by the length of the characters associated to the digit.
    * If the dictionary does not contain a mapping for this digit, check if the character is equal to the characters for a backspace ('*'). If it does equal a backspace, remove the last characer.
* Return the output string.
