using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Roboplas.Business.CustomExceptions;
using Roboplas.Business.Interfaces;
using Roboplas.DataAccess.Interfaces;
using Roboplas.Model.Dtos.User;
using Roboplas.Model.Entities;

namespace Roboplas.Business.Implementations
{
    public class UserBs : IUserBs
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        public UserBs(IUserRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<ApiResponse<UserGetDto>> GetByIdAsync(int departmentId, params string[] includeList)
        {
            if (departmentId <= 0)
            {
                throw new BadRequestException("Id değeri 0'dan büyük olmalıdır");
            }
            var department = await _repo.GetByIdAsync(departmentId, includeList);
            if (department != null)
            {
                var dto = _mapper.Map<UserGetDto>(department);
                return ApiResponse<UserGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }
        public async Task<ApiResponse<UserGetDto>> InsertAsync(UserPostDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek user bilgisi yollamalısınız");
            }
            dto.UserName = dto.UserName.Trim();
            if (dto.UserName.Length < 3)
            {
                throw new BadRequestException("Kullanıcı adı en az 3 karakter olmalıdır.");
            }
            dto.FullName = dto.FullName.Trim();
            if (dto.FullName.Length < 3)
            {
                throw new BadRequestException("İsim en az 3 karakter olmalıdır.");
            }
            if (dto.Email == null)
            {
                throw new BadRequestException("Email boş geçilemez.");
            }
            if (dto.Password.Length < 5)
            {
                throw new BadRequestException("Şifre en az 5 karakter olmalıdır.");
            }
            var user = _mapper.Map<User>(dto);
            var insertedUser = await _repo.InsertAsync(user);
            var retUser = _mapper.Map<UserGetDto>(insertedUser);
            return ApiResponse<UserGetDto>.Success(StatusCodes.Status201Created, retUser);
        }

        public async Task<ApiResponse<UserGetDto>> LogIn(string userName, string password, params string[] includeList)
        {
            userName = userName.Trim();
            if (string.IsNullOrEmpty(userName))
            {
                throw new BadRequestException("Kullanıcı Adı Boş Bırakılamaz.");
            }

            if (userName.Length <= 2)
            {
                throw new BadRequestException("Kullanıcı Adı en az 3 karakter olmalıdır.");
            }

            password = password.Trim();
            if (string.IsNullOrEmpty(password))
            {
                throw new BadRequestException("Şifre Boş Bırakılamaz.");
            }

            var adminUser = await _repo.GetByUserNameAndPasswordAsync(userName, password, includeList);

            if (adminUser != null)
            {
                var dto = _mapper.Map<UserGetDto>(adminUser);
                return ApiResponse<UserGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }
    }
}
