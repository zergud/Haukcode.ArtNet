namespace Haukcode.ArtNet.Rdm.Packets.Control;

/// <summary>
/// This parameter is used for the user to physically identify the device represented by the UID.
/// </summary>
/// <remarks>
/// The responder shall physically identify itself using a visible or audible action. For example,
/// strobing a light or outputting fog.
/// </remarks>
public class IdentifyDevice
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.IdentifyDevice);

    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.IdentifyDevice)
    {
        public bool IdentifyEnabled { get; set; }
        protected internal override void ReadData(RdmBinaryReader data)
        {
            IdentifyEnabled = data.ReadBool();
        }
        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteBool(IdentifyEnabled);
        }
    }

    public class Set() : RdmRequestPacket(RdmCommands.Set, RdmParameters.IdentifyDevice)
    {
        public bool IdentifyEnabled { get; set; }
        protected internal override void ReadData(RdmBinaryReader data)
        {
            IdentifyEnabled = data.ReadBool();
        }
        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteBool(IdentifyEnabled);
        }
    }

    public class SetReply() : RdmResponsePacket(RdmCommands.SetResponse, RdmParameters.IdentifyDevice);
}
