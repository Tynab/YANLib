using AutoMapper;
using Volo.Abp.Application.Dtos;

namespace YANLib;

public class BaseAutoMapperProfile : Profile
{
    public BaseAutoMapperProfile() => CreateMap(typeof(PagedResultDto<>), typeof(PagedResultDto<>));
}
