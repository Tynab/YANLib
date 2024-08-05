using System.Threading.Tasks;

namespace YANLib.SignalRHub;

public interface INotificationHub
{
    public ValueTask SendNotification(string message);
}
