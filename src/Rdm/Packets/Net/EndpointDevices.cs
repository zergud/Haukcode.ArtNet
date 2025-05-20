namespace Haukcode.ArtNet.Rdm.Packets.Net;

public class EndpointDevices
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.EndpointDevices)
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

    public class Reply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.EndpointDevices)
    {
        public ushort EndpointID { get; set; }

        public int ListChangeNumber { get; set; }

        private List<UId?> deviceIds = new List<UId?>();

        public List<UId?> DeviceIds
        {
            get { return deviceIds; }
            set { deviceIds = value; }
        }


        protected internal override void ReadData(RdmBinaryReader data)
        {
            EndpointID = data.ReadUInt16();
            ListChangeNumber = data.ReadInt32();

            for (int n = 0; n < (ParameterDataLength - 6) / 6; n++)
            {
                DeviceIds.Add(data.ReadUId());
            }
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteUInt16(EndpointID);
            data.WriteInt32(ListChangeNumber);

            foreach (UId? id in DeviceIds)
                data.WriteUid(id);
        }
    }
}
