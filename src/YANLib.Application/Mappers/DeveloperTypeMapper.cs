using AutoMapper;
using System.Collections.Generic;
using Volo.Abp.AutoMapper;
using YANLib.Entities;
using YANLib.RedisDtos;
using YANLib.Requests;
using YANLib.Responses;

namespace YANLib.Mappers;

public sealed class DeveloperTypeMapper : Profile
{
    public DeveloperTypeMapper()
    {
        _ = CreateMap<KeyValuePair<string, DeveloperTypeDto>, DeveloperTypeResponse>()
            .ForMember(d => d.Code, o => o.MapFrom(s => s.Key.ToInt()))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Value.Name))
            .ForMember(d => d.IsActive, o => o.MapFrom(s => s.Value.IsActive))
            .ForMember(d => d.CreatedDate, o => o.MapFrom(s => s.Value.CreatedDate))
            .ForMember(d => d.ModifiedDate, o => o.MapFrom(s => s.Value.ModifiedDate));

        _ = CreateMap<DeveloperTypeDto, DeveloperTypeResponse>()
            .Ignore(d => d.Code);

        _ = CreateMap<DeveloperTypeRequest, DeveloperType>()
            .Ignore(d => d.CreatedDate)
            .Ignore(d => d.ModifiedDate);

        _ = CreateMap<DeveloperType, DeveloperTypeDto>();

        _ = CreateMap<DeveloperType, DeveloperTypeResponse>();

        _ = CreateMap<DeveloperTypeResponse, DeveloperType>();
    }
}
