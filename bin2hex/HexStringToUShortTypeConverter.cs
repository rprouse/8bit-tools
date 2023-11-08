using System.ComponentModel;
using System.Globalization;

public class HexStringToUShortTypeConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType) =>
        sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        if (value is string str)
        {
            if (ushort.TryParse(str, NumberStyles.AllowHexSpecifier | NumberStyles.HexNumber, null, out var result))
            {
                return result;
            }
        }
        return null;
    }
}
