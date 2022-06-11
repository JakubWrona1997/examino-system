using Examino.Application.Hubs;
using Examino.Domain.Contracts;
using Examino.Domain.DTOs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Infrastructure.Services
{
    public class HangFireService : IHangFireService
    {
        private readonly IHubContext<EventHub> _eventHub;

        public HangFireService(IHubContext<EventHub> eventHub)
        {
            _eventHub = eventHub;           
        }
        public async Task RunMessageTask(string receiver, string sender, string raportId)
        {
            string[] users = new string[]
            {
                receiver,
                sender,             
            };

            var message = new Message()
            {
                TextMessage = "Nowy raport został dodany!",
                FromUserId = sender,
                ToUserId = receiver,
                RaportId = raportId
            };
           await _eventHub.Clients.Users(users).SendAsync("RaportAdded", message);
        }
    }

}
