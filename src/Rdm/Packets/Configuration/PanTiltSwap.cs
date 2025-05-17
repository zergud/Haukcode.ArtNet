namespace Haukcode.ArtNet.Rdm.Packets.Configuration;

public class PanTiltSwap
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.PanTiltSwap);

    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.PanTiltSwap)
    {
        public bool Swapped { get; set; }
        protected internal override void ReadData(RdmBinaryReader data)
        {
            Swapped = data.ReadBool();
        }
        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteBool(Swapped);
        }
    }

    public class Set() : RdmRequestPacket(RdmCommands.Set, RdmParameters.PanTiltSwap)
    {
        public bool Swapped { get; set; }
        protected internal override void ReadData(RdmBinaryReader data)
        {
            Swapped = data.ReadBool();
        }
        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteBool(Swapped);
        }
    }

    public class SetReply() : RdmResponsePacket(RdmCommands.SetResponse, RdmParameters.PanTiltSwap);
}
