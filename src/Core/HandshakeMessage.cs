namespace Belly.RtmpServer.Core;

public class HandshakeMessage
{
    public uint TimestatmpPrevious { get; init; }

    public uint TimestatmpReceived { get; init; }

    public byte[] RandomData { get; init; }
}