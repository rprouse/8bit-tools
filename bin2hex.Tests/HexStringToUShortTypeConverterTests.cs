[TestFixture]
public class HexStringToUShortTypeConverterTests
{
    [Test]
    public void CanConvertFrom_String_ReturnsTrue()
    {
        var converter = new HexStringToUShortTypeConverter();
        var result = converter.CanConvertFrom(null, typeof(string));
        result.Should().BeTrue();
    }

    [Test]
    public void CanConvertFrom_NonString_ReturnsFalse()
    {
        var converter = new HexStringToUShortTypeConverter();
        var result = converter.CanConvertFrom(null, typeof(int));
        result.Should().BeFalse();
    }

    [Test]
    public void ConvertFrom_ValidHexString_ReturnsUShort()
    {
        var converter = new HexStringToUShortTypeConverter();
        var result = converter.ConvertFrom(null, null, "FFFF");
        result.Should().BeOfType<ushort>();
        result.Should().Be((ushort)65535);
    }

    [Test]
    public void ConvertFrom_InvalidHexString_ReturnsBaseConvertFrom()
    {
        var converter = new HexStringToUShortTypeConverter();
        var result = converter.ConvertFrom(null, null, "G");
        result.Should().BeNull();
    }
}
