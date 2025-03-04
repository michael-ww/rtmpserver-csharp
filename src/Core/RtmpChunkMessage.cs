namespace Belly.RtmpServer.Core;

public class RtmpChunkMessage
{
    public byte ChunkType { get; init; }

    public uint? ChunkStreamID { get; init; }

    public uint? ExtendedTimestamp { get; init; }
    
    public byte[] ChunkPayload{ get; init; }
}