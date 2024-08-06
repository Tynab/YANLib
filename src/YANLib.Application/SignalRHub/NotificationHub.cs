using Volo.Abp.AspNetCore.SignalR;

namespace YANLib.SignalRHub;

// Route: /signalr-hubs/notification
[HubRoute("/yanlib/notification")]
public class NotificationHub : AbpHub { }
