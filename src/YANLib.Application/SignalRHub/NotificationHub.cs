using Volo.Abp.AspNetCore.SignalR;

namespace YANLib.SignalRHub;

/* 
{
  "protocol": "json",
  "version": 1
}
*/

[HubRoute("/yanlib/notification")]
public class NotificationHub : AbpHub { }
