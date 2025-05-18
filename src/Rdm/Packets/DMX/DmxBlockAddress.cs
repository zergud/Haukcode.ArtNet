﻿namespace Haukcode.ArtNet.Rdm.Packets.DMX;

/// <summary>
/// This parameter provides a mechanism for block addressing the DMX512 start address of sub-devices. 
/// </summary>
/// <remarks>
/// Sub-devices implementations, such as dimmer racks, are often composed of an array of sub-devices (i.e. 
/// dimmer modules) that allow a DMX512 start address to be set for the sub-device. Often it is desirable to 
/// linearly address the sub-devices to consume a contiguous block of DMX512 slots. This message 
/// provides a convenient way of accomplishing this without the need of sending a SET_COMMAND 
/// message to address each sub-device. 
/// </remarks>
public class DmxBlockAddress
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.DmxBlockAddress);

    public class GetReply : RdmResponsePacket
    {
        public GetReply()
            : base(RdmCommands.GetResponse, RdmParameters.DmxBlockAddress)
        {
        }

        /// <summary>
        /// The Total Sub-Device Footprint shall return the total combined DMX512 footprint (number of consecutive 
        /// DMX512 slots required) of all the sub-devices within the device.
        /// </summary>
        /// <remarks>
        /// The footprint of the root device shall not be included within this footprint field. 
        /// </remarks>
        public ushort TotalDeviceFootprint { get; set; }

        /// <summary>
        /// The first DMX address of all sub-devices.
        /// </summary>
        /// <remarks>
        /// The GET_COMMAND returns the current base DMX512 start address for the array of sub-devices. This 
        /// is equivalent to the DMX512 Start Address of the first sub-device if the sub-devices are all linearly 
        /// addressed as a contiguous block. If the sub-devices are not currently linearly addressed as a contiguous 
        /// block then this field shall be set to 0xFFFF in the response message. 
        /// </remarks>
        public ushort DmxAddress { get; set; }

        protected internal override void ReadData(RdmBinaryReader data)
        {
            TotalDeviceFootprint = data.ReadUInt16();
            DmxAddress = data.ReadUInt16();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteUInt16(TotalDeviceFootprint);
            data.WriteUInt16(DmxAddress);
        }
    }

    public class Set() : RdmRequestPacket(RdmCommands.Set, RdmParameters.DmxBlockAddress)
    {
        /// <summary>
        /// The first DMX address of all sub-devices.
        /// </summary>
        /// <remarks>
        /// The SET_COMMAND shall set the DMX512 address for the first sub-device to the specified address and 
        /// the device shall automatically address each sub-device incrementally accounting for the footprint size of 
        /// each sub-device. 
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

    public class SetReply() : RdmResponsePacket(RdmCommands.SetResponse, RdmParameters.DmxBlockAddress);
}
