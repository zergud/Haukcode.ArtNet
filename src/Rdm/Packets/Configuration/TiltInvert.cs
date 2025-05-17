namespace Haukcode.ArtNet.Rdm.Packets.Configuration;

public class TiltInvert
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.TiltInvert);

    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.TiltInvert)
    {
        public bool Inverted { get; set; }
        protected internal override void ReadData(RdmBinaryReader data)
        {
            Inverted = data.ReadBool();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteBool(Inverted);
        }
    }

    public class Set() : RdmRequestPacket(RdmCommands.Set, RdmParameters.TiltInvert)
    {
        public bool Inverted { get; set; }
        protected internal override void ReadData(RdmBinaryReader data)
        {
            Inverted = data.ReadBool();
        }
        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteBool(Inverted);
        }
    }

    public class SetReply() : RdmResponsePacket(RdmCommands.SetResponse, RdmParameters.TiltInvert);
}
