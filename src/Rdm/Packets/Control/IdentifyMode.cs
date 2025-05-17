namespace Haukcode.ArtNet.Rdm.Packets.Control;

/// <summary>
/// Different modes for identifying fixtures.
/// </summary>
public enum IdentifyModes
{
    Quit = 0x0,
    Loud = 0xFF
}

/// <summary>
/// This parameter is used to get or set the RDM Identify Mode. 
/// </summary>
/// <remarks>
/// This parameter allows devices to have different Identify Modes for use with the IDENTIFY_DEVICE 
/// message. 
/// </remarks>
public class IdentifyMode
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.IdentifyMode);

    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.IdentifyMode)
    {
        public IdentifyModes IdentifyMode { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            IdentifyMode = (IdentifyModes) data.ReadByte();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteByte((byte) IdentifyMode);
        }
    }

    public class Set() : RdmRequestPacket(RdmCommands.Set, RdmParameters.IdentifyMode)
    {
        public IdentifyModes IdentifyMode { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            IdentifyMode = (IdentifyModes) data.ReadByte();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteByte((byte) IdentifyMode);
        }
    }

    public class SetReply() : RdmResponsePacket(RdmCommands.SetResponse, RdmParameters.IdentifyMode);
}
