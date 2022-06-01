using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Users.Login.Queries.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<UserViewModel>
    {
        public Guid UserId { get; set; }
        public GetUserDetailsQuery(Guid id)
        {
            UserId = id;
        }
    }
}
