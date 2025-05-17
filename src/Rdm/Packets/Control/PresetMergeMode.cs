namespace Haukcode.ArtNet.Rdm.Packets.Control;

public class PresetMergeMode
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.PresetMergeMode);
    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.PresetMergeMode);
    public class Set() : RdmRequestPacket(RdmCommands.Set, RdmParameters.PresetMergeMode);
    public class SetReply() : RdmResponsePacket(RdmCommands.SetResponse, RdmParameters.PresetMergeMode);
}
