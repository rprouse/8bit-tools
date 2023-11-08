namespace bin2hex.Tests;

public class Bin2HexCommandTests
{
    [TestCase("test.bin", "test.hex")]
    [TestCase("test", "test.hex")]
    [TestCase("..\\bin\\test.bin", "..\\bin\\test.hex")]
    [TestCase("bin\\test", "bin\\test.hex")]
    [TestCase("D:\\bin\\test", "D:\\bin\\test.hex")]
    [TestCase("D:\\bin\\test.bin", "D:\\bin\\test.hex")]
    public void HexFileFromInput_ReturnsCorrectFileName(string input, string expected)
    {
        string actual = Bin2HexCommand.HexFileFromInput(input);
        actual.Should().Be(expected);
    }
}
