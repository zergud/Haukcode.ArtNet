namespace Haukcode.ArtNet.Rdm.Packets.Control;

/// <summary>
/// This parameter is used to retrieve or change the current device Power State. Power State
/// specifies the current operating mode of the device.
/// </summary>
public class PowerState
{
    public enum States
    {
        Off = 0x0,
        Shutdown = 0x1,
        Standby = 0x2,
        Normal = 0xffff
    }

    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.PowerState);
    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.PowerState)
    {
        public States State { get; set; }
        protected internal override void ReadData(RdmBinaryReader data)
        {
            State = (States)data.ReadByte();
        }
        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteByte((byte) State);
        }
    }
    public class Set() : RdmRequestPacket(RdmCommands.Set, RdmParameters.PowerState)
    {
        public States State { get; set; }
        protected internal override void ReadData(RdmBinaryReader data)
        {
            State = (States)data.ReadByte();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteByte((byte)State);
        }
    }
    public class SetReply() : RdmResponsePacket(RdmCommands.SetResponse, RdmParameters.PowerState);
}
