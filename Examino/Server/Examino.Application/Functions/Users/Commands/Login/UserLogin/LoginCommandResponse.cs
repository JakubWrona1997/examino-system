using Examino.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Users.Commands.Login.UserLogin
{
    public class LoginCommandResponse : BaseResponse
    {

        public string Token { get; set; }

        public LoginCommandResponse(string token) : base()
        {
            Token = token;
        }
        public LoginCommandResponse(int statusCode, bool success) : base(statusCode, success)
        {

        }
        public LoginCommandResponse(int statusCode, string message, bool success) : base(statusCode, message, success)
        {

        }

    }

}
