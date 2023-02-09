using IronSoftChallenge;

Console.WriteLine("Please enter the T9 input: ");
string input = Console.ReadLine();

if (String.IsNullOrEmpty(input))
{
    Console.WriteLine("Input is null");
    return;
}
string text = T9Converter.OldPhonePad(input);
Console.WriteLine(text);
