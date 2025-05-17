namespace Haukcode.ArtNet.Rdm.Packets.Control;

public class PowerOnSelfTest
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.PowerOnSelfTest);
    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.PowerOnSelfTest);
    public class Set() : RdmRequestPacket(RdmCommands.Set, RdmParameters.PowerOnSelfTest);
    public class SetReply() : RdmResponsePacket(RdmCommands.SetResponse, RdmParameters.PowerOnSelfTest);
}
