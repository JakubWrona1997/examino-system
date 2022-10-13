using Examino.Domain.Entities;

namespace Examino.Domain.Contracts
{
    public interface IRaportRepository
    {
        Task<Raport?> GetById(Guid id);
        Task<Guid> CreateRaport(Raport raport);
        Task CreatePrescription(Prescription prescription);
        Task<bool> UpdateRaport(Raport raport, int id);
        Task DeleteRaport(Raport raport);
        bool IsCreateCompleted();
    }
}
