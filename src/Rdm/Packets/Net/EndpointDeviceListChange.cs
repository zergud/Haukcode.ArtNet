namespace Haukcode.ArtNet.Rdm.Packets.Net;

public class EndpointDeviceListChange
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.EndpointDeviceListChange)
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

    public class Reply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.EndpointDeviceListChange)
    {
        public ushort EndpointID { get; set; }

        public int ListChangeNumber { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            EndpointID = data.ReadUInt16();
            ListChangeNumber = data.ReadInt32();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteUInt16(EndpointID);
            data.WriteInt32(ListChangeNumber);
        }
    }
}
