using Infrastructure.Utilities.ApiResponse;
using Infrastructure.Utilities.ApiResponses;
using Roboplas.Model.Dtos.Task;

namespace Roboplas.Business.Interfaces
{
    public interface IDutyBs
    {
        Task<ApiResponse<List<DutyGetDto>>> GetByUserIdAsync(int userId, params string[] includeList);
        Task<ApiResponse<DutyGetDto>> GetByIdAsync(int dutyId, params string[] includeList);
        Task<ApiResponse<DutyGetDto>> InsertAsync(DutyPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(DutyPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
        Task<ApiResponse<NoData>> UpdateForStatus(int id);
    }
}
