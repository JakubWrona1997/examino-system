using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Login.Commands.Login
{
    public  class LoginCommand:IRequest<LoginCommandResponse>
    {
        public string Email { get; set; }
        public string  Password { get; set; }
    }
}
