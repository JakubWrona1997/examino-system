﻿using Examino.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Domain.Contracts
{
    public interface IPatientRepository
    {
        Task<bool> Register(Patient patient);
    }
}
