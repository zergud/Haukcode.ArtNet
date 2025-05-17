namespace Haukcode.ArtNet.Rdm.Packets.Configuration;

/// <summary>
/// This parameter is used to retrieve or set the real-time clock in a device.
/// </summary>
public class RealTimeClock
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.RealTimeClock);

    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.RealTimeClock)
    {
        public DateTime ClockTime { get; set; }
        protected internal override void ReadData(RdmBinaryReader data)
        {
            ClockTime = new DateTime(
                data.ReadInt16(), //Year    
                data.ReadByte(), //Month
                data.ReadByte(), //Day
                data.ReadByte(), //Hour
                data.ReadByte(), //Minute
                data.ReadByte()); //Second
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteUInt16((ushort)ClockTime.Year);
            data.WriteByte((byte)ClockTime.Month);
            data.WriteByte((byte)ClockTime.Day);
            data.WriteByte((byte)ClockTime.Hour);
            data.WriteByte((byte)ClockTime.Minute);
            data.WriteByte((byte)ClockTime.Second);
        }
    }

    public class Set() : RdmRequestPacket(RdmCommands.Set, RdmParameters.RealTimeClock)
    {
        public DateTime ClockTime { get; set; }
        protected internal override void ReadData(RdmBinaryReader data)
        {
            ClockTime = new DateTime(
                data.ReadInt16(), //Year    
                data.ReadByte(), //Month
                data.ReadByte(), //Day
                data.ReadByte(), //Hour
                data.ReadByte(), //Minute
                data.ReadByte()); //Second
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteUInt16((ushort)ClockTime.Year);
            data.WriteByte((byte)ClockTime.Month);
            data.WriteByte((byte)ClockTime.Day);
            data.WriteByte((byte)ClockTime.Hour);
            data.WriteByte((byte)ClockTime.Minute);
            data.WriteByte((byte)ClockTime.Second);
        }
    }

    public class SetReply() : RdmResponsePacket(RdmCommands.SetResponse, RdmParameters.RealTimeClock);
}