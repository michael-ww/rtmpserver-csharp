namespace Belly.RtmpServer.Core;

using System.Collections.Concurrent;
using System.Threading.Tasks;

public class RtmpConnection
{
    private readonly RtmpMessageEncoder rtmpMessageEncoder;
    private readonly RtmpMessageDecoder rtmpMessageDecoder;
    private readonly ConcurrentDictionary<ushort, RtmpStream> rtmpStreams;

    public async ValueTask StartAsync()
    {
        
    }
}