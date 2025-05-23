﻿namespace Haukcode.ArtNet.Rdm;

public class RdmEndPoint : IPEndPoint
{
    public RdmEndPoint(IPAddress ipAddress)
        : this(ipAddress, 0, 0)
    {
    }

    public RdmEndPoint(IPAddress ipAddress, ushort universe)
        : this(ipAddress, 0, universe)
    {
    }

    public RdmEndPoint(IPEndPoint ipEndPoint)
        : this(ipEndPoint.Address, ipEndPoint.Port, 0)
    {
    }

    public RdmEndPoint(IPEndPoint ipEndPoint, ushort universe)
        : this(ipEndPoint.Address, ipEndPoint.Port, universe)
    {
    }

    public RdmEndPoint(IPAddress ipAddress, int port, ushort universe)
        : base(ipAddress, port)
    {
        IpAddress = ipAddress;
        Universe = universe;
    }

    private IPAddress ipAddress = IPAddress.Any;

    public IPAddress IpAddress
    {
        get { return ipAddress; }
        set { ipAddress = value; }
    }

    private UId id = UId.Empty;

    public UId Id
    {
        get { return id; }
        set { id = value; }
    }

    private UId gatewayId = UId.Empty;

    public UId GatewayId
    {
        get { return gatewayId; }
        set { gatewayId = value; }
    }

    private ushort universe = 0;

    public ushort Universe
    {
        get { return universe; }
        set { universe = value; }
    }

    public override string ToString()
    {
        return IpAddress.ToString();
    }
}
