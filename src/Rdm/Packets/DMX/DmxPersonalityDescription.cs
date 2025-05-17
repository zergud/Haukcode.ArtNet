namespace Haukcode.ArtNet.Rdm.Packets.DMX;

public class DmxPersonalityDescription
{
    public class Get : RdmRequestPacket
    {
        public Get()
            : base(RdmCommands.Get,RdmParameters.DmxPersonalityDescription)
        {
        }

        public byte PersonalityIndex { get; set; }

        #region Read and Write

        protected internal override void ReadData(RdmBinaryReader data)
        {
            PersonalityIndex = data.ReadByte();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteByte(PersonalityIndex);
        }

        #endregion
    }

    public class GetReply : RdmResponsePacket
    {
        public GetReply()
            : base(RdmCommands.GetResponse, RdmParameters.DmxPersonalityDescription)
        {
        }

        public byte PersonalityIndex { get; set; }

        public ushort DmxSlotsRequired { get; set; }

        public string? Description { get; set; }
        
        #region Read and Write

        protected internal override void ReadData(RdmBinaryReader data)
        {
            PersonalityIndex = data.ReadByte();
            DmxSlotsRequired = data.ReadUInt16();
            if(ParameterDataLength > 3)
                Description = data.ReadString(ParameterDataLength - 3);
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteByte(PersonalityIndex);
            data.WriteUInt16(DmxSlotsRequired);
            data.WriteString(Description);
        }

        #endregion
    }
}
