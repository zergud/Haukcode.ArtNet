namespace Haukcode.ArtNet.Rdm.Packets.Net;

/// <summary>
/// This parameter is used to retrieve a packed list of all endpoints that exist on an E1.33 device, with the exception of the Management Endpoint.
/// </summary>
/// <remarks>
/// The list of Endpoint IDs shall not include the Management Endpoint ID. If the device does not have any Endpoints (other than the Management Endpoint) then it shall return a PDL of 0.
/// </remarks>
public class EndpointList
{
    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.EndpointList);

    public class Reply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.EndpointList)
    {
        public int ListChangeNumber { get; set; }

        public List<ushort> EndpointIDs { get; set; } = new List<ushort>();

        protected internal override void ReadData(RdmBinaryReader data)
        {
            ListChangeNumber = data.ReadInt32();

            List<ushort> endpoints = new List<ushort>();
            for (int n = 0; n < ((ParameterDataLength - 4) / 2); n++)
            {
                endpoints.Add(data.ReadUInt16());
            }

            EndpointIDs = endpoints;
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            data.WriteInt32(ListChangeNumber);
            foreach (ushort endpointId in EndpointIDs)
            {
                data.WriteUInt16(endpointId);
            }
        }
    }
}
