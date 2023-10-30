using Infrastructure.DataAccess.Implementations.EF;
using Roboplas.DataAccess.EF.Contexts;
using Roboplas.DataAccess.Interfaces;
using Roboplas.Model.Entities;

namespace Roboplas.DataAccess.EF.Repositories
{
    public class UserRepository : BaseRepository<User, RoboplasContext>, IUserRepository
    {
        public async Task<User> GetByUserNameAndPasswordAsync(string userName, string password, params string[] includeList)
        {
            return await GetAsync(x => x.UserName == userName && x.Password == password, includeList);
        }

        public async Task<User> GetByIdAsync(int userId, params string[] includeList)
        {
            return await GetAsync(usr => usr.Id == userId, includeList);
        }
    }
}
