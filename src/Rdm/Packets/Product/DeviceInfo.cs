﻿namespace Haukcode.ArtNet.Rdm.Packets.Product;

/// <summary>
/// This parameter is used to retrieve a variety of information about the device that is normally
/// required by a controller.
/// </summary>
public class DeviceInfo
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.DeviceInfo);

    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.DeviceInfo)
    {
        public short RdmProtocolVersion { get; set; }

        public short DeviceModelId { get; set; }

        public ProductCategories ProductCategory { get; set; }

        public int SoftwareVersionId { get; set; }

        public ushort DmxFootprint { get; set; }

        public byte DmxPersonality { get; set; }

        public byte DmxPersonalityCount { get; set; }

        public ushort DmxStartAddress { get; set; }

        public ushort SubDeviceCount { get; set; }

        public byte SensorCount { get; set; }

        #region Read and Write

        protected internal override void ReadData(RdmBinaryReader data)
        {
            RdmProtocolVersion = data.ReadInt16();
            DeviceModelId = data.ReadInt16();
            ProductCategory = (ProductCategories) data.ReadInt16();
            SoftwareVersionId = data.ReadInt32();
            DmxFootprint = data.ReadUInt16();
            DmxPersonality = data.ReadByte();
            DmxPersonalityCount = data.ReadByte();
            DmxStartAddress = data.ReadUInt16();
            SubDeviceCount = data.ReadUInt16();
            SensorCount = data.ReadByte();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteInt16(RdmProtocolVersion);
            data.WriteInt16(DeviceModelId);
            data.WriteInt16((short) ProductCategory);
            data.WriteInt32(SoftwareVersionId);
            data.WriteUInt16(DmxFootprint);
            data.WriteByte(DmxPersonality);
            data.WriteByte(DmxPersonalityCount);
            data.WriteUInt16(DmxStartAddress);
            data.WriteUInt16(SubDeviceCount);
            data.WriteByte(SensorCount);
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0}",ProductCategory.ToString());
        }
    }
}
