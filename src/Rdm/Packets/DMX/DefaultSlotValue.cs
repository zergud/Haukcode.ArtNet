namespace Haukcode.ArtNet.Rdm.Packets.DMX;

/// <summary>
/// This parameter shall be used for requesting the default values for the given DMX512 slot offsets
/// for a device.
/// </summary>
public class DefaultSlotValue
{
    public struct SlotValue(short offset, byte value)
    {
        public short Offset { get; set; } = offset;

        public byte Value { get; set; } = value;
    }

    public class Get() : RdmResponsePacket(RdmCommands.Get, RdmParameters.DefaultSlotValue);

    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.DefaultSlotValue)
    {
        public List<SlotValue> DefaultValues { get; set; } = new();

        protected internal override void ReadData(RdmBinaryReader data)
        {
            for (int n = 0; n < ParameterDataLength / 3; n++)
            {
                SlotValue slot = new SlotValue();
                slot.Offset = data.ReadInt16();
                slot.Value = data.ReadByte();
                DefaultValues.Add(slot);
            }
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            foreach (SlotValue value in DefaultValues)
            {
                data.WriteInt16(value.Offset);
                data.WriteByte(value.Value);
            }
        }
    }
}
