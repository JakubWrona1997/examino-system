using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Raports.Commands.DeleteRaport
{
    public record DeleteRaportCommand : IRequest
    {
        public Guid RaportId { get; set; }
    }
}
