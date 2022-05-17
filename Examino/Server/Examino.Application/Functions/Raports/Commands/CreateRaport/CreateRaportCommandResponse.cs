using Examino.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Raports.Commands.CreateRaport
{
    public class CreateRaportCommandResponse : BaseResponse
    {
        public Guid? Id { get; set; }
        public CreateRaportCommandResponse() : base()
        {

        }
        public CreateRaportCommandResponse(Guid guid) : base()
        {
            Id = guid;
        }
        public CreateRaportCommandResponse(string message) : base(message)
        {

        }
        public CreateRaportCommandResponse(int statusCode, bool success) : base(statusCode, success)
        {

        }
        public CreateRaportCommandResponse(int statusCode, string message, bool success) : base(statusCode, message, success)
        {

        }
    }
}
