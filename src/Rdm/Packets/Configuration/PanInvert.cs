namespace Haukcode.ArtNet.Rdm.Packets.Configuration;

/// <summary>
/// This parameter is used to retrieve or change the Pan Invert setting.
/// </summary>
public class PanInvert
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.PanInvert);

    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.PanInvert)
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

    public class Set() : RdmRequestPacket(RdmCommands.Set, RdmParameters.PanInvert)
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

    public class SetReply() : RdmResponsePacket(RdmCommands.SetResponse, RdmParameters.PanInvert);
}
