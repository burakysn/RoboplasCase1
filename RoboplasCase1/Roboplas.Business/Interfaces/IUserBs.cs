using Infrastructure.Utilities.ApiResponses;
using Roboplas.Model.Dtos.User;

namespace Roboplas.Business.Interfaces
{
    public interface IUserBs
    {
        Task<ApiResponse<UserGetDto>> LogIn(string userName, string password, params string[] includeList);
        Task<ApiResponse<UserGetDto>> GetByIdAsync(int userId, params string[] includeList);
        Task<ApiResponse<UserGetDto>> InsertAsync(UserPostDto dto);
    }
}
