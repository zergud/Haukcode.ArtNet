namespace Haukcode.ArtNet.Rdm.Packets.DMX;

/// <summary>
/// This parameter is used to set or get the DMX512 start address.
/// </summary>
/// <remarks>
/// The DMX512 Starting Address can also be retrieved as part of the DEVICE_INFO Parameter
/// Message in Section 10.5.1.
/// 
/// The returned data represents the address in the range 1 to 512. A value of zero represents ‘Not
/// Set’. When this message is directed to a Root Device or Sub-Device that has a DMX512
/// Footprint of 0 for that Root or Sub-Device, then the response shall be set to 0xFFFF. Values
/// outside this range are beyond the scope of this standard.
/// </remarks>
public class DmxStartAddress
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.DmxStartAddress);

    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.DmxStartAddress)
    {
        /// <summary>
        /// The DMX512 start address for the fixture.
        /// </summary>
        /// <remarks>
        /// This should be in the range of 1 to 512. A value
        /// of zero indicates the parameter is not set.
        /// </remarks>
        public ushort DmxAddress { get; set; }
        
        protected internal override void ReadData(RdmBinaryReader data)
        {
            DmxAddress = data.ReadUInt16();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteUInt16(DmxAddress);
        }
    }

    public class Set() : RdmRequestPacket(RdmCommands.Set, RdmParameters.DmxStartAddress)
    {
        /// <summary>
        /// The DMX512 start address for the fixture.
        /// </summary>
        /// <remarks>
        /// This should be in the range of 1 to 512. A value
        /// of zero indicates the parameter is not set.
        /// </remarks>
        public ushort DmxAddress { get; set; }
        
        protected internal override void ReadData(RdmBinaryReader data)
        {
            DmxAddress = data.ReadUInt16();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteUInt16(DmxAddress);
        }
    }

    public class SetReply() : RdmResponsePacket(RdmCommands.SetResponse, RdmParameters.DmxStartAddress);
}
