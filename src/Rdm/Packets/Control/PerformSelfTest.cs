namespace Haukcode.ArtNet.Rdm.Packets.Control;

public class PerformSelfTest
{
    public enum TestMode
    {
        Off = 0x0,
        All = 0xFF
    }

    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.PerformSelfTest);

    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.PerformSelfTest)
    {
        public bool IsTestActive { get; set; }
        protected internal override void ReadData(RdmBinaryReader data)
        {
            IsTestActive = data.ReadBool();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteBool(IsTestActive);
        }
    }

    public class Set() : RdmRequestPacket(RdmCommands.Set, RdmParameters.PerformSelfTest);

    public class SetReply() : RdmResponsePacket(RdmCommands.SetResponse, RdmParameters.PerformSelfTest)
    {
        public byte TestNumber { get; set; }
        protected internal override void ReadData(RdmBinaryReader data)
        {
            TestNumber = data.ReadByte();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteByte(TestNumber);
        }
    }
}
