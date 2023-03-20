using Microsoft.AspNetCore.SignalR;
namespace RealTimeEventService.Api.Hubs
{
    public class EventHub : Hub
    {
        // Metodo responsável pela criação e inclusão de um client
        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
