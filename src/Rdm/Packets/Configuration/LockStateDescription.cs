namespace Haukcode.ArtNet.Rdm.Packets.DMX;

public class LockStateDescription
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.LockStateDescription);

    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.LockStateDescription);

    public class Set() : RdmRequestPacket(RdmCommands.Set, RdmParameters.LockStateDescription);

    public class SetReply() : RdmResponsePacket(RdmCommands.SetResponse, RdmParameters.LockStateDescription);
}
