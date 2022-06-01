using Examino.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Users.Login.Commands.UserLogin
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly ILoginService _loginService;

        public LoginCommandHandler(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public  Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = _loginService.GenerateJwt(request.Email, request.Password);
            if (result is null)  return Task.FromResult(new LoginCommandResponse(404,"Niepoporawny Email lub Hasło",false));
            return Task.FromResult( new LoginCommandResponse(result));          
        }
    }
}
