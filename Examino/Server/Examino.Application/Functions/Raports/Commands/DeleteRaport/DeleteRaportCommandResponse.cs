using Examino.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Raports.Commands.DeleteRaport
{
    public class DeleteRaportCommandResponse : BaseResponse
    {
        public Guid? Id { get; set; }
        public DeleteRaportCommandResponse() : base()
        {

        }
        public DeleteRaportCommandResponse(Guid guid) : base()
        {
            Id = guid;
        }
        public DeleteRaportCommandResponse(string message) : base(message)
        {

        }
        public DeleteRaportCommandResponse(int statusCode, bool success) : base(statusCode, success)
        {

        }
    }
}
