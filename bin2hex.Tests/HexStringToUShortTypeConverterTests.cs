namespace bin2hex.Tests;

[TestFixture]
public class HexStringToUShortTypeConverterTests
{
    HexStringToUShortTypeConverter _converter;

    [SetUp]
    public void SetUp()
    {
        _converter = new HexStringToUShortTypeConverter();
    }

    [Test]
    public void CanConvertFrom_String_ReturnsTrue()
    {
        var result = _converter.CanConvertFrom(null, typeof(string));
        result.Should().BeTrue();
    }

    [Test]
    public void CanConvertFrom_NonString_ReturnsFalse()
    {
        var result = _converter.CanConvertFrom(null, typeof(int));
        result.Should().BeFalse();
    }

    [TestCase("FFFF", 0xFFFF)]
    public void ConvertFrom_ValidHexString_ReturnsUShort(string hex, int expected)
    {
        var result = _converter.ConvertFrom(null, null, hex);
        result.Should().BeOfType<ushort>();
        result.Should().Be((ushort)expected);
    }

    [Test]
    public void ConvertFrom_InvalidHexString_ReturnsBaseConvertFrom()
    {
        var result = _converter.ConvertFrom(null, null, "G");
        result.Should().BeNull();
    }
}
