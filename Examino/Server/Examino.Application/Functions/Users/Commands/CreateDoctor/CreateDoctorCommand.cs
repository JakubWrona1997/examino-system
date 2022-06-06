using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Users.Commands.CreateDoctor
{
    public class CreateDoctorCommand : IRequest<CreateDoctorCommandResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PESEL { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
