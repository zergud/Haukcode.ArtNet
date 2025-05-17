namespace Haukcode.ArtNet.Rdm.Packets.Net;

public class EndpointTimingDescription
{
    public class Get : RdmRequestPacket
    {
        public Get()
            : base(RdmCommands.Get, RdmParameters.EndpointTimingDescription)
        {
        }

        public byte SettingIndex { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            SettingIndex = data.ReadByte();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteByte(SettingIndex);
        }
    }

    public class GetReply : RdmResponsePacket
    {
        public GetReply()
            : base(RdmCommands.GetResponse, RdmParameters.EndpointTimingDescription)
        {
        }

        public byte SettingIndex { get; set; }

        public string? Description { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            SettingIndex = data.ReadByte();
            Description = data.ReadString(ParameterDataLength - 1);
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteByte(SettingIndex);
            data.WriteString(Description);
        }
    }
}
