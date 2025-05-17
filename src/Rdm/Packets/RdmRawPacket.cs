namespace Haukcode.ArtNet.Rdm.Packets;

public class RdmRawPacket : RdmPacket
{
    public RdmRawPacket()
        : base()
    {
    }

    public RdmRawPacket(RdmCommands command, RdmParameters parameterId)
        : base(command, parameterId)
    {
    }


    public byte[] Data { get; set; } = [];

    #region Read and Write

    protected internal override void ReadData(RdmBinaryReader data)
    {
        Data = data.ReadBytes(ParameterDataLength);
    }

    protected internal override void WriteData(RdmBinaryWriter data)
    {
        data.WriteBytes(Data);
    }

    #endregion

}
