namespace Haukcode.ArtNet.Rdm.Packets.DMX;

/// <summary>
/// This parameter is used for requesting an ASCII text description for DMX512 slot offsets.
/// </summary>
/// <remarks>
/// If the responder does not support the Slot number requested, or cannot provide a text description
/// for a slot number that it does support, the responder shall respond with
/// NR_DATA_OUT_OF_RANGE.
/// </remarks>
public class SlotDescription
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.SlotDescription)
    {
        public short SlotOffset { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            SlotOffset = data.ReadInt16();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteInt16(SlotOffset);
        }
    }

    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.SlotDescription)
    {
        public short SlotOffset { get; set; }
        public string? Description { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            SlotOffset = data.ReadInt16();
            Description = data.ReadString(ParameterDataLength - 2);
        }
        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteInt16(SlotOffset);
            data.WriteString(Description);
        }
    }
}
