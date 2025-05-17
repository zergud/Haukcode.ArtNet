namespace Haukcode.ArtNet.Rdm;

public class ArtNetEventArgs(ArtNetPacket packet, IPEndPoint source) : EventArgs
{
    public ArtNetPacket Packet = packet;
    public IPEndPoint Source = source;
}

public class RdmEventArgs(RdmPacket packet, IPEndPoint source) : EventArgs
{
    public RdmPacket Packet = packet;
    public IPEndPoint Source = source;
}