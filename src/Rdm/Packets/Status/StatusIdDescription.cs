namespace Haukcode.ArtNet.Rdm.Packets.Status;

/// <summary>
/// This parameter is used to request an ASCII text description of a given Status ID. The description
/// may be up to 32 characters.
/// </summary>
public class StatusIdDescription
{

    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.StatusIdDescription)
    {
        /// <summary>
        /// The status to request the description for.
        /// </summary>
        public ushort StatusId { get; set; }

        #region Read and Write

        protected internal override void ReadData(RdmBinaryReader data)
        {
            StatusId = data.ReadUInt16();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteUInt16(StatusId);
        }

        #endregion
    }

    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.StatusIdDescription)
    {
        /// <summary>
        /// The description for the requested status.
        /// </summary>
        public string? Description { get; set; }

        #region Read and Write

        protected internal override void ReadData(RdmBinaryReader data)
        {
            Description = data.ReadString(ParameterDataLength);
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            if (!string.IsNullOrEmpty(Description))
            {
                data.WriteString(Description);
            }
        }

        #endregion
    }
}
