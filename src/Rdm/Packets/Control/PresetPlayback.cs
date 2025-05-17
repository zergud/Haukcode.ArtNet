namespace Haukcode.ArtNet.Rdm.Packets.Control;

/// <summary>
/// This parameter is used to recall pre-recorded Presets.
/// </summary>
public class PresetPlayback
{
    public enum PlayMode
    {
        Off = 0x0,
        Scene = 0x1,
        All = 0xffff
    }

    public class Get() : RdmRequestPacket(RdmCommands.Get, RdmParameters.PresetPlayback);

    public class GetReply() : RdmResponsePacket(RdmCommands.GetResponse, RdmParameters.PresetPlayback)
    {
        public PlayMode Mode { get; set; }
        public ushort SceneNumber { get; set; }
        protected internal override void ReadData(RdmBinaryReader data)
        {
            SceneNumber = (ushort) data.ReadInt16();
            if (SceneNumber > (ushort) PlayMode.Off || SceneNumber < (ushort) PlayMode.All)
                Mode = PlayMode.Scene;
            else
                Mode = (PlayMode) SceneNumber;
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            if (Mode == PlayMode.Scene)
                data.WriteUInt16(SceneNumber);
            else
                data.WriteUInt16((ushort)Mode);
        }
    }

    public class Set() : RdmRequestPacket(RdmCommands.Set, RdmParameters.PresetPlayback)
    {
        public PlayMode Mode { get; set; }
        public ushort SceneNumber { get; set; }
        public byte Level { get; set; }
        protected internal override void ReadData(RdmBinaryReader data)
        {
            SceneNumber = (ushort) data.ReadInt16();
            if (SceneNumber > (ushort)PlayMode.Off || SceneNumber < (ushort)PlayMode.All)
                Mode = PlayMode.Scene;
            else
                Mode = (PlayMode)SceneNumber;
            Level = data.ReadByte();
        }

        protected internal override void WriteData(RdmBinaryWriter data)
        {
            if (Mode == PlayMode.Scene)
                data.WriteUInt16(SceneNumber);
            else
                data.WriteUInt16((ushort)Mode);
            data.WriteByte(Level);
        }
    }
    public class SetReply() : RdmResponsePacket(RdmCommands.SetResponse, RdmParameters.PresetPlayback);
}
