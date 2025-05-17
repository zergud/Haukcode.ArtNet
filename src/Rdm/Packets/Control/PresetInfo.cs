namespace Haukcode.ArtNet.Rdm.Packets.Control;

public class PresetInfo
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.PresetInfo);
    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.PresetInfo);
}
