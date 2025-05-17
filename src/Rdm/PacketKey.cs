namespace Haukcode.ArtNet.Rdm;

public struct PacketKey(RdmCommands command, RdmParameters parameter) : IEquatable<PacketKey>
{
    public RdmCommands Command = command;
    public RdmParameters Parameter = parameter;

    public bool Equals(PacketKey other)
    {
        return Command == other.Command && Parameter == other.Parameter;
    }

    public override bool Equals(object? obj)
    {
        return obj is PacketKey other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine((int)Command, (int)Parameter);
    }

    public static bool operator ==(PacketKey left, PacketKey right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(PacketKey left, PacketKey right)
    {
        return !(left == right);
    }
}