using Microsoft.AspNetCore.SignalR;
using NeoForum.Models;

namespace NeoForum.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message) =>
            await Clients.All.SendAsync("receiveMessage", message);
    }
}
