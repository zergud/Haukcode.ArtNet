namespace Haukcode.ArtNet.Rdm.Packets.Net;

public class BackgroundQueuedStatusPolicy
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.BackgroundQueuedStatusPolicy)
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

    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.BackgroundQueuedStatusPolicy)
    {
        public ushort EndpointID { get; set; }

        public byte CurrentPolicyID { get; set; }

        public byte PolicyCount { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            EndpointID = data.ReadUInt16();
            CurrentPolicyID = data.ReadByte();
            PolicyCount = data.ReadByte();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteUInt16(EndpointID);
            data.WriteByte(CurrentPolicyID);
            data.WriteByte(PolicyCount);
        }
    }

    public class Set() : RdmRequestPacket(RdmCommands.Set, RdmParameters.BackgroundQueuedStatusPolicy)
    {
        public ushort EndpointID { get; set; }

        public byte CurrentPolicyID { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            EndpointID = data.ReadUInt16();
            CurrentPolicyID = data.ReadByte();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteUInt16(EndpointID);
            data.WriteByte(CurrentPolicyID);
        }
    }

    public class SetReply() : RdmResponsePacket(RdmCommands.SetResponse, RdmParameters.BackgroundQueuedStatusPolicy);
}
