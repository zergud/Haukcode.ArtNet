namespace Haukcode.ArtNet.Rdm.Packets.Net;

public class BackgroundDiscovery
{
    public class Get : RdmRequestPacket
    {
        public Get()
            : base(RdmCommands.Get,RdmParameters.BackgroundDiscovery)
        {
        }

        public short EndpointID { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            EndpointID = data.ReadInt16();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteUInt16(EndpointID);
        }
    }

    public class GetReply : RdmResponsePacket
    {
        public GetReply()
            : base(RdmCommands.GetResponse, RdmParameters.BackgroundDiscovery)
        {
        }

        public short EndpointID { get; set; }

        /// <summary>
        /// Controls whether background discovery is enabled within the RDM device.
        /// </summary>
        public bool BackgroundDiscovery { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            EndpointID = data.ReadInt16();
            BackgroundDiscovery = data.ReadBool();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteUInt16(EndpointID);
            data.WriteBool(BackgroundDiscovery);
        }
    }

    public class Set : RdmRequestPacket
    {
        public Set()
            : base(RdmCommands.Set, RdmParameters.BackgroundDiscovery)
        {
        }

        public short EndpointID { get; set; }

        /// <summary>
        /// Controls whether background discovery is enabled within the RDM device.
        /// </summary>
        public bool BackgroundDiscovery { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            EndpointID = data.ReadInt16();
            BackgroundDiscovery = data.ReadBool();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteUInt16(EndpointID);
            data.WriteBool(BackgroundDiscovery);
        }
    }

    public class SetReply : RdmResponsePacket
    {
        public SetReply()
            : base(RdmCommands.SetResponse, RdmParameters.BackgroundDiscovery)
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
