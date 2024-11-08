using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using YANLib.Requests;

namespace YANLib.Services;

public interface INotificationService : IApplicationService
{
    public ValueTask Send(NotificationRequest request);

    public ValueTask Schedule(NotificationRequest request);
}
