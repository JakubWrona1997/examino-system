using Examino.Domain.Contracts;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examino.Application.Hubs
{
    public class Message
    {
        public string ToUserId { get; set; }
        public string FromUserId { get; set; }
        public string TextMessage { get; set; }
    }
    public class EventHub : Hub
    {
        private readonly IUserProvider _userProvider;

        public EventHub(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        public async Task SendMessage(Message message)
        {
            var users = new string[] 
            { 
                message.ToUserId,
                message.FromUserId = _userProvider.GetUserId().ToString()
            };
            await Clients.Users(users).SendAsync("ReceiveMessage", message);
        }
    }
}
