namespace Belly.RtmpServer.Net;

using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Net.Sockets;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

public class SocketConnection(Socket socket, PipeWriter input, PipeReader output, ILogger logger)
{
    private readonly ILogger logger = logger;
    private readonly Socket socket = socket;
    private readonly PipeReader output = output;
    private readonly PipeWriter input = input;
    private readonly IList<ArraySegment<byte>> forSending = [];

    public string ID { get; init; } = $"{DateTimeOffset.Now.ToString("yyyyMMddHHmmssfff")}{Random.Shared.Next(100, 999)}";
    public bool IsConnected => this.socket?.Connected ?? false;
    public string LocalEndPoint => this.socket?.LocalEndPoint?.ToString() ?? string.Empty;
    public string RemoteEndPoint => this.socket?.RemoteEndPoint?.ToString() ?? string.Empty;

    public async Task StartAsync()
    {
        Task recevingTask = this.DoReceving();
        Task sendingTask = this.DoSending();
        await Task.WhenAll(recevingTask, sendingTask);
    }

    public override string ToString()
    {
        return $"[{this.ID},{this.LocalEndPoint},{this.RemoteEndPoint}]";
    }

    private async Task DoReceving()
    {
        while (true)
        {
            try
            {
                Memory<byte> memory = this.input.GetMemory();
                int bytesReceived = await this.socket.ReceiveAsync(memory);
                if (bytesReceived <= 0)
                {
                    break;
                }
                this.input.Advance(bytesReceived);
            }
            catch (Exception exception)
            {
                this.logger.LogError(exception, $"{this} DoReceiving Exception");
                break;
            }
        }
    }

    private async Task DoSending()
    {
        while (true)
        {
            try
            {
                ReadResult readResult = await this.output.ReadAsync();
                if (readResult.IsCanceled)
                {
                    break;
                }
                if (!readResult.Buffer.IsEmpty)
                {
                    if (readResult.Buffer.IsSingleSegment)
                    {
                        await this.socket.SendAsync(readResult.Buffer.First);
                    }
                    else
                    {
                        this.forSending.Clear();
                        foreach (var item in readResult.Buffer)
                        {
                            this.forSending.Add(item.ToArray());
                        }
                        await this.socket.SendAsync(this.forSending);
                    }
                    this.output.AdvanceTo(readResult.Buffer.End);
                }
                if (readResult.IsCompleted)
                {
                    break;
                }
            }
            catch (Exception exception)
            {
                this.logger.LogError(exception, $"{this} DoSending Exception");
                break;
            }
        }
    }
}
