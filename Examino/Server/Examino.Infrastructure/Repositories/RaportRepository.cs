using Examino.Domain.Contracts;
using Examino.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Examino.Infrastructure.Repositories
{
    public class RaportRepository : IRaportRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private bool _isCompleted;
        public RaportRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreatePrescription(Prescription prescription)
        {
            _dbContext.Prescriptions.Add(prescription);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Guid> CreateRaport(Raport raport)
        {
            raport.RaportTime = DateTimeOffset.Now;

            _dbContext.Raports.Add(raport);
            var records = await _dbContext.SaveChangesAsync();

            _isCompleted = records > 0;

            return raport.Id;         
        }

        public async Task DeleteRaport(Raport raport)
        {
            _dbContext.Raports.Remove(raport);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Raport?> GetById(Guid id)
        {
            var result = await _dbContext.Raports
                .Include(i => i.Prescription)
                .Include(i => i.Patient)
                .Include(i => i.Doctor)
                .FirstOrDefaultAsync(x=>x.Id == id);

            return result;
        }

        public Task<bool> UpdateRaport(Raport raport, int id)
        {
            throw new NotImplementedException();
        }
        public bool IsCreateCompleted() => _isCompleted;
    }
}
