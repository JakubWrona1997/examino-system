﻿using Examino.Domain.Contracts;
using Examino.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Infrastructure.Repositories
{
    public class RaportRepository : IRaportRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RaportRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> CreateRaport(Raport raport)
        {
            _dbContext.Raports.Add(raport);
            await _dbContext.SaveChangesAsync();
            return raport.Id;
        }

        public async Task DeleteRaport(Raport raport)
        {
            if (raport == null)
                await Task.FromResult<object>(null);
            //Notfoundexception should be implemented here

            _dbContext.Raports.Remove(raport);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Raport> GetById(Guid id)
        {
            var result = await _dbContext.Raports
                .Include(i => i.Prescription)
                .Include(i => i.Patient)
                .Include(i => i.Doctor)
                .FirstOrDefaultAsync(x=>x.Id == id);

            if(result == null)
                return null;

            return result;
        }

        public Task<bool> UpdateRaport(Raport raport, int id)
        {
            throw new NotImplementedException();
        }
    }
}
