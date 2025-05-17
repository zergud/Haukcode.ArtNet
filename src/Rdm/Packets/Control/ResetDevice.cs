namespace Haukcode.ArtNet.Rdm.Packets.Control;

/// <summary>
/// This parameter is used to instruct the responder to reset itself. This parameter shall also clear the
/// Discovery Mute flag. A cold reset is the equivalent of removing and reapplying power to the
/// device.
/// </summary>
public class ResetDevice
{
    public enum ResetType
    {
        WarmReset = 0x1,
        ColdReset = 0xFF
    }

    public class Set() : RdmRequestPacket(RdmCommands.Set, RdmParameters.ResetDevice)
    {
        public ResetType Reset { get; set; }
        protected internal override void ReadData(RdmBinaryReader data)
        {
            Reset = (ResetType)data.ReadByte();
        }
        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteByte((byte)Reset);
        }
    }
    public class SetReply() : RdmResponsePacket(RdmCommands.SetResponse, RdmParameters.ResetDevice);
}
