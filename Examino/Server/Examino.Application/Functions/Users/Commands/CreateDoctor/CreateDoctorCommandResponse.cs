using Examino.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Users.Commands.CreateDoctor
{
    public class CreateDoctorCommandResponse : BaseResponse
    {
        public CreateDoctorCommandResponse() : base()
        {

        }
        public CreateDoctorCommandResponse(string message) : base(message)
        {

        }
        public CreateDoctorCommandResponse(int statusCode, bool success) : base(statusCode, success)
        {

        }
        public CreateDoctorCommandResponse(int statusCode, string message, bool success) : base(statusCode, message, success)
        {

        }
    }
}
