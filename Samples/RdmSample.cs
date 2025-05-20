using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Haukcode.ArtNet.Internal;
using Haukcode.ArtNet.Packets;
using Haukcode.ArtNet.Rdm;
using Haukcode.ArtNet.Rdm.IO;
using Haukcode.ArtNet.Rdm.Packets.Product;


namespace Haukcode.ArtNet.Samples;

/// <summary>
/// Discovery all rdm devices and request DeviceLabels
/// </summary>
public class RdmSample
{
    private readonly ArtRdmService _service;
    private readonly List<(UId uid, short universe, IPEndPoint ip)> devices = new();
    private int deviceCount;

    public RdmSample(IPAddress localIp, IPAddress localSubnetMask)
    {
        _service = new ArtRdmService(localIp, localSubnetMask);
        _service.OnArtNetPacketReceived += OnArtNetPacketReceived;
        _service.OnRdmPacketReceived += OnRdmPacketReceived;
    }

    private void OnRdmPacketReceived(object? sender, RdmEventArgs e)
    {
        if (e.Packet is DeviceLabel.GetReply deviceLabel)
        {
            Console.WriteLine($"{deviceCount--} Response from device: {deviceLabel.SourceId} Label='{deviceLabel.Label}'");
                        
        }
    }

    private void OnArtNetPacketReceived(object? sender, ArtNetEventArgs e)
    {
        switch (e.Packet.OpCode)
        {
            case ArtNetOpCodes.PollReply:
                if (e.Packet is ArtPollReplyPacket pollReply)
                {
                    ProcessPollReply(pollReply, e.Source);
                }
                break;
            case ArtNetOpCodes.TodData:
                if (e.Packet is ArtTodDataPacket todData)
                {
                    ProcessTodData(todData, e.Source);
                }
                break;
        }
    }

   

    public async Task SendArtPoll()
    {
        await _service.client.QueuePacketForSending((IPAddress)null, new ArtPollPacket {TalkToMe = 2});
    }


    private async void ProcessPollReply(ArtPollReplyPacket packet, IPEndPoint source)
    {
        try
        {
            Console.WriteLine($"ArtPollReply - Name: {packet.LongName} IP:{new IPAddress(packet.IpAddress)} " +
                              $"BindIndex: {packet.BindIndex}   report: {packet.NodeReport}");

            
            ArtTodRequestPacket tod = new()
            {
                Command = 0,
                Net = packet.NetSwitch
            };


            for (int n = 0; n < packet.PortCount; n++)
            {
                if ((packet.PortTypes[n] & (byte)PollReplyPortTypes.IsOutputPort) ==
                    (byte)PollReplyPortTypes.IsOutputPort)
                {
                    var address = (byte)((packet.SubSwitch << 4) + packet.SwOut[n]);

                    byte swOut = packet.SwOut[n];
                    tod.RequestedUniverses.Add((byte)((packet.SubSwitch << 4) + swOut));
                }
            }
            await _service.client.QueuePacketForSending(source, tod);
            await Task.Delay(10);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private void ProcessTodData(ArtTodDataPacket packet, IPEndPoint source)
    {
        //byte port = (byte)(packet.BindIndex - 1 + packet.Port);
        foreach (var uid in packet.Devices)
        {
            Console.WriteLine($"found in TOD: universe: {packet.Universe}  UId:{uid}");
            devices.Add((uid, packet.Universe, source));
        }
    }

    public async void GetDeviceLabels()
    {
        try
        {
            Console.WriteLine($"Total devices: {devices.Count}");
            deviceCount = devices.Count;
        
            foreach (var dev in devices)
            {
                RdmPacket packet = new DeviceLabel.Get();
                await _service.SendRdm(packet, dev.ip, dev.universe, dev.uid, UId.Empty);
                await Task.Delay(10);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}