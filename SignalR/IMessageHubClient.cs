using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SzkolaKomunikator.SignalR
{
    public interface IMessageHubClient
    {
        Task BroadcastMessage(string message);
    }
    public class MessageHub : Hub<IMessageHubClient>
    {
        public void AddToGroup(string groupName)
        {
            Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }
        public void RemoveFromGroup(string groupName)
        {
            Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
