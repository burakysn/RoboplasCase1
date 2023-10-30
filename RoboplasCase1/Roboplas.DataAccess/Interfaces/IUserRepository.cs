using Infrastructure.DataAccess.Interfaces;
using Roboplas.Model.Entities;

namespace Roboplas.DataAccess.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByUserNameAndPasswordAsync(string userName, string password, params string[] includeList);
        Task<User> GetByIdAsync(int departmentId, params string[] includeList);
    }
}
