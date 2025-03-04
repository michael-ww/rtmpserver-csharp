namespace Belly.RtmpServer.Core;

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;

public class RtmpServer
{
    private Socket socketListener;
    private readonly ConcurrentQueue<RtmpConnection> rtmpConnections;
    private readonly Dictionary<string, IMessageHandler> messageHandlers;

    public async Task StartAsync()
    {

    }

    public async Task StopAsync()
    {
        
    }
}
