namespace bin2hex;

public enum HexRecordType : byte
{
    Data = 0x00,
    EndOfFile = 0x01,
    ExtendedSegmentAddress = 0x02,
    StartSegmentAddress = 0x03,
    ExtendedLinearAddress = 0x04,
    StartLinearAddress = 0x05
}
