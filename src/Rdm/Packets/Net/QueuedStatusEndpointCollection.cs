﻿using Haukcode.ArtNet.Rdm.Packets.Status;

namespace Haukcode.ArtNet.Rdm.Packets.Net;

public class QueuedStatusEndpointCollection
{
    public class Set : RdmRequestPacket
    {
        public Set()
            : base(RdmCommands.Set, RdmParameters.QueuedStatusEndpointCollection)
        {
        }

        public ushort EndpointID { get; set; }

        public StatusTypes StatusType { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            EndpointID = data.ReadUInt16();
            StatusType = (StatusTypes) data.ReadByte();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteUInt16(EndpointID);
            data.WriteByte((byte) StatusType);
        }
    }

    public class SetReply : RdmResponsePacket
    {
        public SetReply()
            : base(RdmCommands.SetResponse, RdmParameters.QueuedStatusEndpointCollection)
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
}
