namespace Haukcode.ArtNet.Rdm.Packets.Net;

public class EndpointLabel
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.EndpointLabel)
    {
        public ushort EndpointID { get; set; }
        protected internal override void ReadData(RdmBinaryReader data)
        {
            EndpointID = data.ReadUInt16();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteUInt16(EndpointID);
        }
    }

    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.EndpointLabel)
    {
        public ushort EndpointID { get; set; }
        public string? Label { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            EndpointID = data.ReadUInt16();
            Label = Encoding.ASCII.GetString(data.ReadBytes(ParameterDataLength-2));
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteUInt16(EndpointID);
            data.WriteString(Label);
        }
    }

    public class Set() : RdmRequestPacket(RdmCommands.Set, RdmParameters.EndpointLabel)
    {
        public ushort EndpointID { get; set; }
        public string? Label { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            EndpointID = data.ReadUInt16();
            Label = Encoding.ASCII.GetString(data.ReadBytes(ParameterDataLength - 2));
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteUInt16(EndpointID);
            data.WriteString(Label);
        }
    }

    public class SetReply() : RdmResponsePacket(RdmCommands.SetResponse, RdmParameters.EndpointLabel);
}
