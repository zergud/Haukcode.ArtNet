namespace Haukcode.ArtNet.Rdm.Packets.Sensors;

public class SensoreValue
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.SensorValue)
    {
        public byte SensorNumber { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            SensorNumber = data.ReadByte();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteByte(SensorNumber);
        }
    }

    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.SensorValue)
    {
        public byte SensorNumber { get; set; }

        public short PresentValue { get; set; }

        public short MinValue { get; set; }

        public short MaxValue { get; set; }

        public short RecordedValue { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            SensorNumber = data.ReadByte();
            PresentValue = data.ReadInt16();
            MinValue = data.ReadInt16();
            MaxValue = data.ReadInt16();
            RecordedValue = data.ReadInt16();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteByte(SensorNumber);
            data.WriteInt16(PresentValue);
            data.WriteInt16(MinValue);
            data.WriteInt16(MaxValue);
            data.WriteInt16(RecordedValue);
        }
    }

    public class Set() : RdmRequestPacket(RdmCommands.Set, RdmParameters.SensorValue)
    {
        public byte SensorNumber { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            SensorNumber = data.ReadByte();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteByte(SensorNumber);
        }

    }

    public class SetReply() : RdmResponsePacket(RdmCommands.SetResponse, RdmParameters.SensorValue)
    {
        public byte SensorNumber { get; set; }

        public short PresentValue { get; set; }

        public short MinValue { get; set; }

        public short MaxValue { get; set; }

        public short RecordedValue { get; set; }

        #region Read and Write

        protected internal override void ReadData(RdmBinaryReader data)
        {
            SensorNumber = data.ReadByte();
            PresentValue = data.ReadInt16();
            MinValue = data.ReadInt16();
            MaxValue = data.ReadInt16();
            RecordedValue = data.ReadInt16();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteByte(SensorNumber);
            data.WriteInt16(PresentValue);
            data.WriteInt16(MinValue);
            data.WriteInt16(MaxValue);
            data.WriteInt16(RecordedValue);
        }

        #endregion
    }
}
