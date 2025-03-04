namespace Belly.RtmpServer.Core;

using System.Threading.Tasks;

public interface IMessageHandler
{
    string MessageType { get; }
    Task HandleAsync(RtmpConnection connection, RtmpMessage message);
}