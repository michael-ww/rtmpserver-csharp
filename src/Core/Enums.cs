namespace Belly.RtmpServer.Core;

public enum MessageType : byte
{
    SetChunkSize,

    AbortMessage,


}

public enum HandshakeState : byte
{
    Uninitialized,
    VersionSent,
    AckSent,
    Done
}