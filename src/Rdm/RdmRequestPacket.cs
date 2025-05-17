namespace Haukcode.ArtNet.Rdm;

public abstract class RdmRequestPacket(RdmCommands command, RdmParameters parameterId) : RdmPacket(command, parameterId)
{
    public byte PortId { get; set; }
}
