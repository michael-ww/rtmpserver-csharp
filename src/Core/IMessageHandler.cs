namespace Belly.RtmpServer.Core;

using System.Threading.Tasks;

public interface IMessageHandler
{
    Task HandleAsync(RtmpConnection connection, RtmpMessage message);
}