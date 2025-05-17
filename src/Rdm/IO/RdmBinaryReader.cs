using Haukcode.Network;

namespace Haukcode.ArtNet.Rdm.IO;

public class RdmBinaryReader(ReadOnlyMemory<byte> buffer) : BigEndianBinaryReader(buffer)
{
    public UId ReadUId()
    {
        return new UId((ushort)ReadInt16(), (uint)ReadInt32());
    }

    public bool ReadBool()
    {
        return ReadByte() != 0;
    }
}
