namespace Belly.RtmpServer.Core;

using System.Collections.Concurrent;

public class RtmpConnection
{
    private readonly ConcurrentDictionary<ushort, RtmpStream> rtmpStreams;
}