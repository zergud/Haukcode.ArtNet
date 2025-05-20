namespace Haukcode.ArtNet.Rdm.Packets.Net;

public class TcpCommsStatus
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.TcpCommsStatus);

    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.TcpCommsStatus)
    {
        public IPAddress CurrentConnectionIP { get; set; }

        public ushort UnhealthyTCPEvents { get; set; }

        public ushort TCPConnectEvents { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            CurrentConnectionIP = new IPAddress(data.ReadBytes(4));
            UnhealthyTCPEvents = data.ReadUInt16();
            TCPConnectEvents = data.ReadUInt16();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteBytes(CurrentConnectionIP.GetAddressBytes());                
            data.WriteUInt16(UnhealthyTCPEvents);
            data.WriteUInt16(TCPConnectEvents);
        }
    }

    public class Set : RdmRequestPacket
    {
        public Set()
            : base(RdmCommands.Set, RdmParameters.EndpointLabel)
        {
        }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            //Parameter Data Empty
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            //Parameter Data Empty
        }
    }

    public class SetReply() : RdmResponsePacket(RdmCommands.SetResponse, RdmParameters.EndpointLabel);
}
