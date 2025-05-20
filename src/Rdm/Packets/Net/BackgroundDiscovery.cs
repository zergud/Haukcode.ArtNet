namespace Haukcode.ArtNet.Rdm.Packets.Net;

public class BackgroundDiscovery
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.BackgroundDiscovery)
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

    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.BackgroundDiscovery)
    {
        public ushort EndpointID { get; set; }

        /// <summary>
        /// Controls whether background discovery is enabled within the RDM device.
        /// </summary>
        public bool BackgroundDiscovery { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            EndpointID = data.ReadUInt16();
            BackgroundDiscovery = data.ReadBool();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteUInt16(EndpointID);
            data.WriteBool(BackgroundDiscovery);
        }
    }

    public class Set() : RdmRequestPacket(RdmCommands.Set, RdmParameters.BackgroundDiscovery)
    {
        public ushort EndpointID { get; set; }

        /// <summary>
        /// Controls whether background discovery is enabled within the RDM device.
        /// </summary>
        public bool BackgroundDiscovery { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            EndpointID = data.ReadUInt16();
            BackgroundDiscovery = data.ReadBool();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteUInt16(EndpointID);
            data.WriteBool(BackgroundDiscovery);
        }
    }

    public class SetReply() : RdmResponsePacket(RdmCommands.SetResponse, RdmParameters.BackgroundDiscovery);
}
