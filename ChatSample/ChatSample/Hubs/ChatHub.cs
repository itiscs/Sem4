using Microsoft.AspNetCore.SignalR;

namespace ChatSample.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.SendAsync("broadcastMessage", message);
        }
    }
}