namespace Haukcode.ArtNet.Rdm.Packets.Net;

public class EndpointIdentify
{
    public class Get : RdmRequestPacket
    {
        public Get()
            : base(RdmCommands.Get, RdmParameters.EndpointIdentify)
        {
        }

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

    public class GetReply : RdmResponsePacket
    {
        public GetReply()
            : base(RdmCommands.GetResponse, RdmParameters.EndpointIdentify)
        {
        }

        public ushort EndpointID { get; set; }

        public bool IdentifyOn { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            EndpointID = data.ReadUInt16();
            IdentifyOn = data.ReadBool();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteUInt16(EndpointID);
            data.WriteBool(IdentifyOn);
        }
    }

    public class Set : RdmRequestPacket
    {
        public Set()
            : base(RdmCommands.Set, RdmParameters.EndpointIdentify)
        {
        }

        public ushort EndpointID { get; set; }

        public bool IdentifyOn { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            EndpointID = data.ReadUInt16();
            IdentifyOn = data.ReadBool();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteUInt16(EndpointID);
            data.WriteBool(IdentifyOn);
        }
    }

    public class SetReply : RdmRequestPacket
    {
        public SetReply()
            : base(RdmCommands.SetResponse, RdmParameters.EndpointIdentify)
        {
        }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            //Parameter Data Empty
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            //Parameter Data Empty
        }
    }


}
