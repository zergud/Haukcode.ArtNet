namespace Haukcode.ArtNet.Rdm.Packets.Management;

public class RdmNack:RdmPacket
{
    public RdmNack()
    {
    }

    public RdmNack(RdmCommands command, RdmParameters parameterId)
        : base(command, parameterId)
    {
        PortOrResponseType = (byte) RdmResponseTypes.NackReason;
    }

    public NackReason Reason { get; set; }

    #region Read and Write

    protected internal override void ReadData(RdmBinaryReader data)
    {
        Reason = (NackReason) data.ReadInt16();
    }

    protected internal override void WriteData(RdmBinaryWriter data)
    {
        data.WriteByte((byte) Reason);
    }

    #endregion
}
