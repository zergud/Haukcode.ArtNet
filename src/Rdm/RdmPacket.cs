namespace Haukcode.ArtNet.Rdm;

public abstract class RdmPacket
{
    protected RdmPacket()
    {
    }

    public RdmPacket(RdmCommands command, RdmParameters parameterId)
    {
        Command = command;
        ParameterId = parameterId;
    }

    #region Contents

    public byte MessageLength { get; set; }

    public UId? DestinationId { get; set; }

    public UId? SourceId { get; set; }

    public byte TransactionNumber { get; set; }

    public byte PortOrResponseType { get; set; }

    public byte MessageCount { get; set; }

    public short SubDevice { get; set; }

    public RdmCommands Command { get; set; }

    public RdmParameters ParameterId { get; set; }

    public byte ParameterDataLength { get; protected set; }

    public short Checksum { get; set; }

    #endregion

    #region Read and Write

    protected abstract void ReadData(RdmBinaryReader data);

    protected abstract void WriteData(RdmBinaryWriter data);

    // public static RdmPacket ReadPacket(RdmBinaryReader data)
    // {
    //     RdmHeader header = new RdmHeader();
    //     header.ReadData(data);
    //
    //     var rdmPacket = Create(header);
    //     if (rdmPacket != null)
    //     {
    //         rdmPacket.ReadData(data);
    //         return rdmPacket;
    //     }
    //
    //     rdmPacket = RdmPacket.Create(header, typeof(RdmRawPacket)) as RdmRawPacket;
    //     if (rdmPacket != null)
    //     {
    //         rdmPacket.ReadData(data);
    //         return rdmPacket;
    //     }
    //
    //     throw new UnknownRdmPacketException(header);            
    // }

    public static RdmPacket? ReadPacket(RdmCommands command, RdmParameters parameterId, RdmBinaryReader contentData)
    {
        RdmPacket? rdmPacket = null;

        RdmHeader header = new RdmHeader
        {
            Command = command,
            ParameterId = parameterId
        };

        rdmPacket = Create(header);
        if (rdmPacket != null)
        {
            rdmPacket.ReadData(contentData);
            return rdmPacket;
        }
        else
        {
            rdmPacket = RdmPacket.Create(header, typeof(RdmRawPacket)) as RdmRawPacket;
            if (rdmPacket != null)
            {
                rdmPacket.ReadData(contentData);
                return rdmPacket;
            }
        }

        throw new UnknownRdmPacketException(header);
    }

    public void ReadPacket(RdmBinaryReader data)
    {
        MessageLength = data.ReadByte();
        DestinationId = data.ReadUId();
        SourceId = data.ReadUId();
        TransactionNumber = data.ReadByte();
        PortOrResponseType = data.ReadByte();
        MessageCount = data.ReadByte();
        SubDevice = data.ReadInt16();
        Command = (RdmCommands)data.ReadByte();
        ParameterId = (RdmParameters)data.ReadInt16();
        ParameterDataLength = data.ReadByte();

        ReadData(data);
    }

    public static RdmRawPacket? ReadPacketRaw(RdmBinaryReader data)
    {
        RdmHeader header = new RdmHeader();
        header.ReadData(data);

        RdmRawPacket? rdmPacket = Create(header, typeof(RdmRawPacket)) as RdmRawPacket;
        rdmPacket?.ReadData(data);

        return rdmPacket;
    }

    public void WritePacket(RdmBinaryWriter data)
    {
        data.WriteByte(MessageLength);
        data.WriteUid(DestinationId);
        data.WriteUid(SourceId);
        data.WriteByte(TransactionNumber);
        data.WriteByte(PortOrResponseType);
        data.WriteByte(MessageCount);
        data.WriteUInt16(SubDevice);
        data.WriteByte((byte)Command);
        data.WriteUInt16((short)ParameterId);
        data.WriteByte(ParameterDataLength);

        WriteData(data);
    }

    public static ushort CalculateChecksum(byte[] data)
    {
        ushort checksum = 0;
        foreach (byte item in data)
            checksum += item;
        return checksum;
    }

    public static ushort CalculateChecksum(byte[] data, int startIndex, int endIndex)
    {
        ushort checksum = 0;
        for (int n = startIndex; n < endIndex; n++)
            checksum += data[n];
        return checksum;
    }

    public bool IsOverflow()
    {
        return (RdmResponseTypes)PortOrResponseType == RdmResponseTypes.AckOverflow &&
               (Command == RdmCommands.GetResponse || Command == RdmCommands.SetResponse);
    }

    #endregion

    public static RdmPacket? Create(RdmHeader header)
    {
        return RdmPacketFactory.Build(header);
    }

    public static RdmPacket? Create(RdmHeader header, Type packetType)
    {
        object? obj = Activator.CreateInstance(packetType);
        if (obj == null)
        {
            return null;
        }

        RdmPacket packet = (RdmPacket)obj;
        packet.Header = header;

        return packet;
    }
}