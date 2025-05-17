namespace Haukcode.ArtNet.Rdm.Packets.Power;

public class BurnIn
{
    public class Get : RdmRequestPacket
    {
        public Get()
            : base(RdmCommands.Get, RdmParameters.BurnIn)
        {
        }
        
        #region Read and Write

        protected internal override void ReadData(RdmBinaryReader data)
        {
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
        }

        #endregion
    }

    public class GetReply : RdmResponsePacket
    {
        public GetReply()
            : base(RdmCommands.GetResponse, RdmParameters.BurnIn)
        {
        }

        #region Read and Write

        protected internal override void ReadData(RdmBinaryReader data)
        {
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
        }

        #endregion
    }

    public class Set : RdmRequestPacket
    {
        public Set()
            : base(RdmCommands.Set, RdmParameters.BurnIn)
        {
        }

        #region Read and Write

        protected internal override void ReadData(RdmBinaryReader data)
        {
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
        }

        #endregion
    }

    public class SetReply : RdmResponsePacket
    {
        public SetReply()
            : base(RdmCommands.SetResponse, RdmParameters.BurnIn)
        {
        }

        #region Read and Write

        protected internal override void ReadData(RdmBinaryReader data)
        {
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
        }

        #endregion
    }
}
