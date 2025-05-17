namespace Haukcode.ArtNet.Rdm.Packets.Control;

/// <summary>
/// This parameter is used to get a descriptive ASCII text label for a given Self Test Operation. The
/// label may be up to 32 characters.
/// </summary>
public class SelfTestDescription
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.SelfTestDescription)
    {
        public byte TestNumber { get; set; }
        protected internal override void ReadData(RdmBinaryReader data)
        {
            TestNumber = data.ReadByte();
        }
        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteByte(TestNumber);
        }
    }

    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.SelfTestDescription)
    {
        public byte TestNumber { get; set; }
        public string? Description { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            TestNumber = data.ReadByte();
            Description = data.ReadString(ParameterDataLength - 1);
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteByte(TestNumber);
            data.WriteString(Description ?? string.Empty, ParameterDataLength - 1);
        }

    }
}
