namespace Haukcode.ArtNet.Rdm.Packets.Configuration;

public class LockPin
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.LockPin);

    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.LockPin)
    {
        public ushort CurrentPinCode { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            CurrentPinCode = data.ReadUInt16();
        }
        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteUInt16(CurrentPinCode);
        }
    }

    public class Set() : RdmRequestPacket(RdmCommands.Set, RdmParameters.LockPin)
    {
        public ushort CurrentPinCode { get; set; }
        public ushort NewPinCode { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            NewPinCode = data.ReadUInt16();
            CurrentPinCode = data.ReadUInt16();
        }
        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteUInt16(NewPinCode);
            data.WriteUInt16(CurrentPinCode);
        }
    }

    public class SetReply() : RdmResponsePacket(RdmCommands.SetResponse, RdmParameters.LockPin);
}
