namespace Haukcode.ArtNet.Rdm;

public abstract class RdmPacket
{
    protected RdmPacket()
    {
    }

    protected RdmPacket(RdmCommands command, RdmParameters parameterId)
    {
        Command = command;
        ParameterId = parameterId;
    }
    public byte MessageLength { get; set; }

    public UId? DestinationId { get; set; }

    public UId? SourceId { get; set; }

    public byte TransactionNumber { get; set; }

    public byte PortOrResponseType { get; set; }

    public byte MessageCount { get; set; }

    public ushort SubDevice { get; set; }

    public RdmCommands Command { get; set; }

    public RdmParameters ParameterId { get; set; }

    public byte ParameterDataLength { get; set; }

    public ushort Checksum { get; set; }

    protected internal virtual void ReadData(RdmBinaryReader data)
    {
    }

    protected internal virtual void WriteData(RdmBinaryWriter data)
    {
    }

    public bool IsOverflow()
    {
        return (RdmResponseTypes)PortOrResponseType == RdmResponseTypes.AckOverflow &&
               (Command == RdmCommands.GetResponse || Command == RdmCommands.SetResponse);
    }
}

// public void WritePacket(RdmBinaryWriter data)
// {
//     data.WriteByte(0xCC);
//     data.WriteByte(0x01);
//     data.WriteByte(0x00); // messageLength
//     data.WriteUid(DestinationId);
//     data.WriteUid(SourceId);
//     data.WriteByte(TransactionNumber);
//     data.WriteByte(PortOrResponseType);
//     data.WriteByte(MessageCount);
//     data.WriteUInt16(SubDevice);
//     data.WriteByte((byte)Command);
//     data.WriteUInt16((ushort)ParameterId);
//     data.WriteByte(0x00); // pdl
//
//     WriteData(data);
//     MessageLength = (byte)data.BytesWritten;
//     ParameterDataLength = (byte)(MessageLength - MinMessageLength);
//     ushort checksum = 0;
//     for (int i = 0; i < data.BytesWritten; i++)
//     {
//         if (i == 2)
//         {
//             data.Memory.Span[i] = MessageLength;
//         }
//
//         if (i == 23)
//         {
//             data.Memory.Span[i] = ParameterDataLength;
//         }
//         checksum += data.Memory.Span[i];
//     }
//     data.WriteUInt16(checksum);    
// }