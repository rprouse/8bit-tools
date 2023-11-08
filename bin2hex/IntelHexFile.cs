using System.Text;

namespace bin2hex;

public static class IntelHexFile
{
    public static string ConvertBinaryToHex(byte[] binary, ushort address)
    {
        StringBuilder sb = new();

        // Split the binary into 16-byte chunks
        for (int i = 0; i < binary.Length; i += 16)
        {
            // Get the next 16 bytes
            byte[] data = binary.Skip(i).Take(16).ToArray();

            // Create the record
            string record = CreateRecord(HexRecordType.Data, address, data);

            // Append the record to the string builder
            sb.Append(record);

            // Increment the address
            address += 16;
        }

        sb.Append(CreateRecord(HexRecordType.EndOfFile, 0x0000, Array.Empty<byte>()));

        return sb.ToString();
    }

    public static string CreateRecord(HexRecordType recordType, ushort address, byte[] data)
    {
        if (data.Length > 255)
            throw new ArgumentException("Data length cannot be greater than 255 bytes.", nameof(data));

        List<byte> record = new()
        {
            (byte)data.Length,
            (byte)(address >> 8),
            (byte)(address & 0xFF),
            (byte)recordType
        };
        record.AddRange(data);
        record.Add(CalculateChecksum(record));

        return record.ToHexString();
    }

    public static byte CalculateChecksum(List<byte> record)
    {
        // Calculate checksum
        byte checksum = 0;
        foreach (byte b in record)
            checksum += b;

        // Two's complement
        checksum = (byte)(0x100 - checksum);
        return checksum;
    }

    public static string ToHexString(this IEnumerable<byte> bytes)
    {
        StringBuilder sb = new();

        sb.Append(':');

        foreach (byte b in bytes)
            sb.Append(b.ToString("X2"));

        sb.Append('\n');

        return sb.ToString();
    }
}