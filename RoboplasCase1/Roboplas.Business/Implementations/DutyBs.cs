using AutoMapper;
using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponse;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Roboplas.Business.CustomExceptions;
using Roboplas.Business.Interfaces;
using Roboplas.DataAccess.Interfaces;
using Roboplas.Model.Dtos.Task;
using Roboplas.Model.Entities;

namespace Roboplas.Business.Implementations
{
    public class DutyBs : IDutyBs
    {
        private readonly IDutyRepository _repo;
        private readonly IMapper _mapper;
        public DutyBs(IDutyRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id değeri 0'dan büyük olmalıdır.");
            }
            var duty = await _repo.GetByIdAsync(id);
            if (duty != null)
            {
                await _repo.DeleteAsync(duty);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("Girilen Id'ye göre içerik bulunamadı.");
        }

        public async Task<ApiResponse<DutyGetDto>> GetByIdAsync(int dutyId, params string[] includeList)
        {
            if (dutyId <= 0)
            {
                throw new BadRequestException("Id değeri 0'dan büyük olmalıdır");
            }
            var duty = await _repo.GetByIdAsync(dutyId, includeList);
            if (duty != null)
            {
                var dto = _mapper.Map<DutyGetDto>(duty);
                return ApiResponse<DutyGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<List<DutyGetDto>>> GetByUserIdAsync(int userId, params string[] includeList)
        {
            var duty = await _repo.GetAllAsync(predicate: k => k.UserId == userId, includeList: includeList);

            if (duty != null && duty.Count > 0)
            {
                var returnList = _mapper.Map<List<DutyGetDto>>(duty);
                var response = ApiResponse<List<DutyGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<DutyGetDto>> InsertAsync(DutyPostDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek görev bilgisi yollamalısınız");
            }
            if (dto.Title == null)
            {
                throw new BadRequestException("Başlık boş geçilemez.");
            }
            if (dto.Description == null)
            {
                throw new BadRequestException("Açıklama boş geçilemez.");
            }
            if (dto.UserId <= 0)
            {
                throw new BadRequestException("User Id değeri 0'dan büyük olmalıdır.");
            }

            var duty = _mapper.Map<Duty>(dto);
            var insertedDuty = await _repo.InsertAsync(duty);
            var retDuty =_mapper.Map<DutyGetDto>(insertedDuty);
            return ApiResponse<DutyGetDto>.Success(StatusCodes.Status201Created, retDuty);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(DutyPutDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek görev bilgisi yollamalısınız");
            }
            if (dto.Title == null)
            {
                throw new BadRequestException("Başlık boş geçilemez.");
            }
            if (dto.Description == null)
            {
                throw new BadRequestException("Açıklama boş geçilemez.");
            }
            if (dto.UserId <= 0)
            {
                throw new BadRequestException("User Id değeri 0'dan büyük olmalıdır.");
            }
            var duty = await _repo.GetByIdAsync(dto.Id);
            if (duty != null)
            {
                var dutyUpdate = _mapper.Map<Duty>(dto);
                await _repo.UpdateAsync(dutyUpdate);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("Güncellemek istediğiniz içerik bulunamadı.");
        }

        public async Task<ApiResponse<NoData>> UpdateForStatus(int id)
        {
            var duty = _repo.GetByIdAsync(id);
            if (duty != null)
            {
                if (duty.Result.Status)
                {
                    duty.Result.Status = false;
                }
                else
                {
                    duty.Result.Status = true;
                }
                await _repo.UpdateAsync(duty.Result);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("Güncellemek istediğiniz içerik bulunamadı.");
        }
    }
}
