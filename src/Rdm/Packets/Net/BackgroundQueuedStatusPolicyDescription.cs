namespace Haukcode.ArtNet.Rdm.Packets.Net;

public class BackgroundQueuedStatusPolicyDescription
{
    public class Get : RdmRequestPacket
    {
        public Get()
            : base(RdmCommands.Get,RdmParameters.BackgroundQueuedStatusPolicyDescription)
        {
        }

        public byte PolicyID { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            PolicyID = data.ReadByte();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteByte(PolicyID);
        }
    }

    public class GetReply : RdmResponsePacket
    {
        public GetReply()
            : base(RdmCommands.GetResponse, RdmParameters.BackgroundQueuedStatusPolicyDescription)
        {
        }

        public byte PolicyID { get; set; }

        public string? Description { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            PolicyID = data.ReadByte();
            Description = data.ReadString(ParameterDataLength - 1);
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteByte(PolicyID);
            data.WriteString(Description);
        }
    }
}
