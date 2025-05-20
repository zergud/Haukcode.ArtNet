namespace Haukcode.ArtNet.Rdm.Packets.Product;

/// <summary>
/// This parameter is used to retrieve the unique Boot Software Version ID for the device. The Boot
/// Software Version ID is a 32-bit value determined by the Manufacturer.
/// </summary>
/// <remarks>
/// The 32-bit Boot Software Version ID may use any encoding scheme such that the Controller may
/// identify devices containing the same boot software versions.
/// 
/// Any devices from the same manufacturer with differing boot software shall not report back the
/// same Boot Software Version ID.
/// </remarks>
public class BootSoftwareVersionId
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.BootSoftwareVersionId);

    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.BootSoftwareVersionId)
    {
        public int VersionId { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            VersionId = data.ReadInt32();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteInt32(VersionId);
        }

    }
}
