using AutoMapper;
using Platform.Service.Dtos;
using Platform.Service.Models;

namespace Platform.Service.Profiles
{
    public class PlatFormsProfile : Profile
    {
        public PlatFormsProfile()
        {
            //Source -> Target
            CreateMap<PlatForm, PlatFormReadDto>();
            CreateMap<PlatFormCreateDto,PlatForm>();
        }
    }
}
