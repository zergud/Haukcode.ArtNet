namespace Haukcode.ArtNet.Rdm.Packets.Configuration;

public class LockState
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.LockState);

    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.LockState)
    {
        public byte CurrentLockState { get; set; }
        protected internal override void ReadData(RdmBinaryReader data)
        {
            CurrentLockState = data.ReadByte();
        }
        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteByte(CurrentLockState);
        }
    }

    public class Set() : RdmRequestPacket(RdmCommands.Set, RdmParameters.LockState)
    {
        public ushort CurrentPinCode { get; set; }
        public byte LockState { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            CurrentPinCode = data.ReadUInt16();
            LockState = data.ReadByte();
        }
        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteUInt16(CurrentPinCode);
            data.WriteByte(LockState);
        }
    }

    public class SetReply() : RdmResponsePacket(RdmCommands.SetResponse, RdmParameters.LockState);
}
