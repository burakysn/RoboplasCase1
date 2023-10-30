using Infrastructure.DataAccess.Interfaces;
using Roboplas.Model.Entities;

namespace Roboplas.DataAccess.Interfaces
{
    public interface IDutyRepository : IBaseRepository<Duty>
    {
        Task<Duty> GetByIdAsync(int dutyId, params string[] includeList);
    }
}
