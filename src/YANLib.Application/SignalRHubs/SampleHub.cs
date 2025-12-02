using Microsoft.AspNetCore.SignalR;
using Volo.Abp.AspNetCore.SignalR;

namespace YANLib.SignalRHubs;

[HubRoute("/signalr/sample")]
public class SampleHub : AbpHub
{
    public override async Task OnConnectedAsync() => await Clients.Caller.SendAsync("ReceiveMessage", "Welcome to YANLib!");
}
