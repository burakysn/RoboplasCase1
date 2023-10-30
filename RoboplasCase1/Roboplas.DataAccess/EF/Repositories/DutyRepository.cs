using Infrastructure.DataAccess.Implementations.EF;
using Roboplas.DataAccess.EF.Contexts;
using Roboplas.DataAccess.Interfaces;
using Roboplas.Model.Entities;

namespace Roboplas.DataAccess.EF.Repositories
{
    public class DutyRepository : BaseRepository<Duty, RoboplasContext>, IDutyRepository
    {
        public async Task<Duty> GetByIdAsync(int dutyId, params string[] includeList)
        {
            return await GetAsync(dpr => dpr.Id == dutyId, includeList);
        }
    }
}
