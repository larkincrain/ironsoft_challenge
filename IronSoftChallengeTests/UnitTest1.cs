using IronSoftChallenge;

namespace IronSoftChallengeTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ItShouldParseDoubleSimilarDigitsCorrectly()
    {
        string input = "33#";
        string expected = "e";
        string actual = T9Converter.OldPhonePad(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ItShouldParseBackspaceCorrectly()
    {
        string input = "227*#";
        string expected = "b";
        string actual = T9Converter.OldPhonePad(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ItShouldParseHelloCorrectly()
    {
        string input = "4433555 555666#";
        string expected = "hello";
        string actual = T9Converter.OldPhonePad(input);
        Assert.AreEqual(expected, actual);
    }

        [Test]
    public void ItShouldParseTurningCorrectly()
    {
        string input = "8 88777444666*664#";
        string expected = "turing";
        string actual = T9Converter.OldPhonePad(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ItShouldParseSingleDigitCorrectly()
    {
        string input = "2#";
        string expected = "a";
        string actual = T9Converter.OldPhonePad(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ItShouldParseMultipleInstancesOfADigitCorrectly()
    {
        string input = "222#";
        string expected = "c";
        string actual = T9Converter.OldPhonePad(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ItShouldParseSimilarDigitsSeparatedByASpaceCorrectly()
    {
        string input = "222 2#";
        string expected = "ca";
        string actual = T9Converter.OldPhonePad(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ItShouldParseALongSeriesOfDigitsCorrectly()
    {
        string input = "233 3445665 5588897777#";
        string expected = "aedhjnjkvws";
        string actual = T9Converter.OldPhonePad(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ItShouldMatchASpaceChacterCorrectly()
    {
        string input = "844 4447777044477770207777 72 22233#";
        string expected = "this is a space";
        string actual = T9Converter.OldPhonePad(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ItShouldParseALongSeriesOfTheSameDigitCorrectly()
    {
        string input = "2222222222222222222222222#";
        string expected = "a";
        string actual = T9Converter.OldPhonePad(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ItShouldCorrectlyParseTheSpecialCharacters()
    {
        string input = "1 11 111 1111#";
        string expected = "&'()";
        string actual = T9Converter.OldPhonePad(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ItShouldThrowAnExceptionIfInputContainsAHashInTheWrongPlace()
    {
        string input = "1 11 1#11 1111#";
        Assert.Catch<Exception>(() => T9Converter.OldPhonePad(input));
    }

    [Test]
    public void ItShouldThrowAnExceptionIfInputDoesNotEndWithAHashCharacter()
    {
        string input = "1 11 111 1111";
        Assert.Catch<Exception>(() => T9Converter.OldPhonePad(input));
    }

    [Test]
    public void ItShouldReturnAnEmptyStringForAnEmptyInput()
    {
        string input = "#";
        string expected = "";
        string actual = T9Converter.OldPhonePad(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ItShouldHandleALeadingBackSpaceCharacterGracefully()
    {
        string input = "*****83377778#";
        string expected = "test";
        string actual = T9Converter.OldPhonePad(input);
        Assert.AreEqual(expected, actual);
    }
}
