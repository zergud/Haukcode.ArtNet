namespace Haukcode.ArtNet.Rdm.Packets.Management;

public class RdmAckTimer : RdmPacket
{
    public RdmAckTimer()
    {
    }

    public RdmAckTimer(RdmCommands command, RdmParameters parameterId)
        : base(command, parameterId)
    {
        PortOrResponseType = (byte)RdmResponseTypes.AckTimer;
    }

    public ushort EstimatedResponseTime { get; set; }

    protected internal override void ReadData(RdmBinaryReader data)
    {
        EstimatedResponseTime = data.ReadUInt16();
    }

    protected internal override void WriteData(RdmBinaryWriter data)
    {
        data.WriteUInt16(EstimatedResponseTime);
    }
}