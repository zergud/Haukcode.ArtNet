using Haukcode.Network;

namespace Haukcode.ArtNet.Rdm.IO;

public class RdmBinaryWriter(Memory<byte> buffer) : BigEndianBinaryWriter(buffer)
{
    public void WriteUid(UId? value)
    {
        ArgumentNullException.ThrowIfNull(value);
        WriteInt16((short)value.ManufacturerId);
        WriteInt32((int)value.DeviceId);
    }

    public void WriteBool(bool value)
    {
        WriteByte(value ? (byte)255 : (byte)0);
    }

    public void WriteString(string? value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            WriteBytes(Encoding.UTF8.GetBytes(value));
        }
    }
}
