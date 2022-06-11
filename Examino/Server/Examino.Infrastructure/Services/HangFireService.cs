using Examino.Application.Hubs;
using Examino.Domain.Contracts;
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
        public void RunMessageTask()
        {
            _eventHub.Clients.All.SendAsync("Added", "Added raport!");
        }
    }
}
