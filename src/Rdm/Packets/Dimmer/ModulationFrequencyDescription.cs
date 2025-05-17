namespace Haukcode.ArtNet.Rdm.Packets.DMX;

public class ModulationFrequencyDescription
{
    public class Get : RdmRequestPacket
    {
        public Get()
            : base(RdmCommands.Get, RdmParameters.ModulationFrequencyDescription)
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
            : base(RdmCommands.GetResponse, RdmParameters.ModulationFrequencyDescription)
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
            : base(RdmCommands.Set, RdmParameters.ModulationFrequencyDescription)
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
            : base(RdmCommands.SetResponse, RdmParameters.ModulationFrequencyDescription)
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
