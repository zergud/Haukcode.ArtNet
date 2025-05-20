using System.Threading.Channels;
using Haukcode.ArtNet.Internal;

namespace Haukcode.ArtNet.Rdm;

public class ArtRdmService: IDisposable
{
    public readonly ArtNetClient client;
    private readonly Task writerTask;
    private readonly RdmPacketFactory packetFactory;
    
    public event EventHandler<ArtNetEventArgs>? OnArtNetPacketReceived;
    public event EventHandler<RdmEventArgs>? OnRdmPacketReceived;

    public ArtRdmService(IPAddress localAddress, IPAddress localSubnetMask, UId? rdmId = null
        )
    {
        packetFactory = new RdmPacketFactory();
        var channel = Channel.CreateUnbounded<ReceiveDataPacket>();
        client = new ArtNetClient(
            localAddress: localAddress,
            localSubnetMask: localSubnetMask,
            channelWriter: p => WritePacket(channel, p),
            channelWriterComplete: () => channel.Writer.Complete(),
            port: 6454,
            rdmId: rdmId);
        writerTask = Task.Factory.StartNew(async () =>
        {
            await WriteToWriterAsync(channel, CancellationToken.None);
        }, CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default).Unwrap();

    }

    public bool RegisterCustomPacket(RdmCommands command, RdmParameters parameter, Func<RdmPacket> packetCreator)
    {
        return packetFactory.RegisterPacketType(command, parameter, packetCreator);
    }
    
    private static async Task WritePacket(Channel<ReceiveDataPacket> channel, ReceiveDataPacket receiveData)
    {
        var dmxData = TransformPacket(receiveData);

        if (dmxData == null)
            return;

        await channel.Writer.WriteAsync(dmxData, CancellationToken.None);
    }

    private static ReceiveDataPacket TransformPacket(ReceiveDataPacket receiveData)
    {
        var copyBuf = new byte[receiveData.Packet.PacketLength];
        receiveData.Packet.WriteToBuffer(copyBuf);

        receiveData.Packet = ArtNetPacket.Parse(copyBuf);

        return receiveData;
    }

    private async Task WriteToWriterAsync(Channel<ReceiveDataPacket> inputChannel, CancellationToken cancellationToken)
    {
        await foreach (var dmxData in inputChannel.Reader.ReadAllAsync(cancellationToken))
        {
            Socket_NewPacket(dmxData.TimestampMS, dmxData);
        }
    }

    private void Socket_NewPacket(double timestampMS, ReceiveDataPacket e)
    {
        if (e.Packet.OpCode != ArtNetOpCodes.Rdm)
        {
            OnArtNetPacketReceived?.Invoke(null, new ArtNetEventArgs(e.Packet, e.Source));
        }

        if (e.Packet is ArtRdmPacket rdmPacket)
        {
            //var reader = new RdmBinaryReader(new MemoryStream(rdmPacket.RdmData));
            var reader = new RdmBinaryReader(rdmPacket.RdmData);   
            var rdm = packetFactory.Parse(reader);
            
            if (rdm != null)
            {
                OnRdmPacketReceived?.Invoke(null, new RdmEventArgs(rdm, e.Source));
                //Console.WriteLine($"Response from device: {rdm.SourceId}");
            }
        }
    }
    
    public Task SendRdm(RdmPacket packet, IPEndPoint targetAddress, short targetUniverse, UId? targetId, UId? sourceId)
    {
        packet.SourceId = sourceId;
        packet.DestinationId = targetId;

        byte[] rdmData = new byte[packet.MessageLength];
            
        var rdmWriter = new RdmBinaryWriter(rdmData);

        //Write the RDM packet
        packetFactory.WritePacket(rdmWriter, packet);
        //
        // //Write the checksum
        // rdmWriter.WriteUInt16((ushort)(RdmPacket.CalculateChecksum(rdmData.GetBuffer()) +
        //                               (int)RdmVersions.SubMessage + (int)DmxStartCodes.RDM));

        //Create sACN Packet
        var rdmPacket = new ArtRdmPacket
        {
            Address = (byte)(targetUniverse & 0x00FF),
            Net = (byte)(targetUniverse >> 8),
            SubStartCode = (byte)RdmVersions.SubMessage,
            RdmData = rdmData.ToArray()
        };

        return client.QueuePacketForSending(targetAddress, rdmPacket);
    }

    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            client.Dispose();
            writerTask.Dispose();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~ArtRdmService()
    {
        Dispose(false);
    }
}