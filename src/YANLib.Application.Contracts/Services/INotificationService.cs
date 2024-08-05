using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace YANLib.Services;

public interface INotificationService : IApplicationService
{
    public ValueTask SendNotification(string message);
}
