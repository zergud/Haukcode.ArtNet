namespace Haukcode.ArtNet.Rdm.Packets.Control;

public class PresetStatus
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.PresetStatus);
    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.PresetStatus);
    public class Set() : RdmRequestPacket(RdmCommands.Set, RdmParameters.PresetStatus);
    public class SetReply() : RdmResponsePacket(RdmCommands.SetResponse, RdmParameters.PresetStatus);
}
