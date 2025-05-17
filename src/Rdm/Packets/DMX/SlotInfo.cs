namespace Haukcode.ArtNet.Rdm.Packets.DMX;

/// <summary>
/// This parameter is used to retrieve basic information about the functionality of the DMX512 slots
/// used to control the device.
/// </summary>
public class SlotInfo
{
    public struct SlotInformation(short offset, SlotTypes type, int slotLink)
    {
        public SlotInformation(short offset, SlotIds id): this(offset, SlotTypes.Primary, 0)
        {
            Id = id;
        }

        public short Offset { get; set; } = offset;

        public SlotTypes Type { get; set; } = type;

        public SlotIds Id
        {
            get => (SlotIds)SlotLink;
            set => SlotLink = (int)value;
        }

        public int SlotLink { get; set; } = slotLink;
    }

    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.SlotInfo);

    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.SlotInfo)
    {
        public List<SlotInformation> Slots { get; set; } = new();

        protected internal override void ReadData(RdmBinaryReader data)
        {
            Slots.Clear();
            for (int n = 0; n < ParameterDataLength / 5; n++)
            {
                SlotInformation slot = new SlotInformation();
                slot.Offset = data.ReadInt16();
                slot.Type = (SlotTypes) data.ReadByte();
                slot.SlotLink = data.ReadInt16();
                Slots.Add(slot);
            }
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            foreach (SlotInformation slot in Slots)
            {
                data.WriteInt16(slot.Offset);
                data.WriteByte((byte) slot.Type);
                data.WriteInt16((short)slot.SlotLink);
            }
        }
    }
}
