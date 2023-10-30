using AutoMapper;
using Roboplas.Model.Dtos.Task;
using Roboplas.Model.Entities;

namespace Roboplas.Business.Profiles
{
    public class DutyProfile : Profile
    {
        public DutyProfile()
        {
            CreateMap<Duty, DutyGetDto>();
            CreateMap<DutyPostDto, Duty>();
            CreateMap<DutyPutDto, Duty>();
        }
    }
}
