using Examino.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Users.Commands.DeleteDoctor
{
    public class DeleteDoctorCommandResponse : BaseResponse
    {
        public Guid? Id { get; set; }
        public DeleteDoctorCommandResponse() : base()
        {

        }
        public DeleteDoctorCommandResponse(Guid guid) : base()
        {
            Id = guid;
        }
        public DeleteDoctorCommandResponse(string message) : base(message)
        {

        }
        public DeleteDoctorCommandResponse(int statusCode, bool success) : base(statusCode, success)
        {

        }
    }
}
