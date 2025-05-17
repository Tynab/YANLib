using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using YANLib.Requests;

namespace YANLib.Services;

public interface INotificationService : IApplicationService
{
    public Task Send(NotificationRequest request);

    public Task Schedule(NotificationRequest request);
}
