﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Application.Functions.Users.Commands.DeleteDoctor
{
    public class DeleteDoctorCommand : IRequest<Guid>
    {
        public Guid DoctorId { get; set; }
    }
}
