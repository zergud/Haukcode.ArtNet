namespace Haukcode.ArtNet.Rdm.Packets.Product;

/// <summary>
/// This parameter provides an ASCII text response with the Manufacturer name for the device of up
/// to 32 characters. The Manufacturer name must be consistent between all products manufactured
/// within an ESTA Manufacturer ID.
/// </summary>
public class ManufacturerLabel
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.ManufacturerLabel);

    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.ManufacturerLabel)
    {
        public string? Label { get; set; }
        protected internal override void ReadData(RdmBinaryReader data)
        {
            Label = data.ReadString(ParameterDataLength);
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteString(Label);
        }
    }
}
