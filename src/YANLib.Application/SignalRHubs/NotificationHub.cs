using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.SignalR;

namespace YANLib.SignalRHubs;

/* 
{
  "protocol": "json",
  "version": 1
}
*/

[HubRoute("/yanlib/notification")]
public class NotificationHub : AbpHub
{
    public override async Task OnConnectedAsync() => await Clients.Caller.SendAsync("ReceiveMessage", "Welcome to YANLib!");
}