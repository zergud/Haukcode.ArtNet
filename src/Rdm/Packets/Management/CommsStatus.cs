namespace Haukcode.ArtNet.Rdm.Packets.Management;

/// <summary>
/// Used to collect information that may be useful in analyzing the integrity of the communication system.
/// </summary>
/// <remarks>
/// A responder shall respond with a cumulative total of each error type in the response message defined below.
/// </remarks>
public class CommsStatus
{
    /// <summary>
    /// Requests information about the amount of errors encountered by a device.
    /// </summary>
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.CommsStatus);

    /// <summary>
    /// Contains information aabout the amount of errors encountered by a device.
    /// </summary>
    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.CommsStatus)
    {
        /// <summary>
        /// The message ended before the Message Length field was received.
        /// </summary>
        public ushort ShortMessage { get; set; }

        /// <summary>
        /// The number of slots actually received did not match the Message Length plus
        /// the size of the Checksum.
        /// </summary>
        /// <remarks>
        /// This counter shall only be incremented if the Destination UID in the
        /// packet matches the Device’s UID.
        /// </remarks>
        public ushort LengthMismatch { get; set; }

        /// <summary>
        /// The message checksum failed.
        /// </summary>
        /// <remarks>
        /// This counter shall only be incremented if the Destination UID in the packet matches the Device’s UID.
        /// </remarks>
        public ushort ChecksumFail { get; set; }
        protected internal override void ReadData(RdmBinaryReader data)
        {
            ShortMessage = data.ReadUInt16();
            LengthMismatch = data.ReadUInt16();
            ChecksumFail = data.ReadUInt16();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteUInt16(ShortMessage);
            data.WriteUInt16(LengthMismatch);
            data.WriteUInt16(ChecksumFail);
        }
    }

    /// <summary>
    /// Clears all the error counts to zero.
    /// </summary>
    public class Set() : RdmRequestPacket(RdmCommands.Set, RdmParameters.CommsStatus);

    /// <summary>
    /// Confirmation that the error counts have been cleared to zero.
    /// </summary>
    public class SetReply() : RdmResponsePacket(RdmCommands.SetResponse, RdmParameters.CommsStatus);
}
