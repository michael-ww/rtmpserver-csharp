namespace Belly.RtmpServer.Core;

public class RtmpMessage
{
    public uint Timestamp{ get; init; }

    public uint PayloadLength{ get; init; }

    public MessageType MessageType{ get; init; }

    public uint MessageStreamID{ get; init; }
}