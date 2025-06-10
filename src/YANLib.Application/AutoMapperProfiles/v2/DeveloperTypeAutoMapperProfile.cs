using AutoMapper;
using System;
using System.Collections.Generic;
using Volo.Abp.AutoMapper;
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.RedisDtos;
using YANLib.Requests.v2.Create;
using YANLib.Requests.v2.Update;
using YANLib.Responses;
using static System.DateTime;

namespace YANLib.AutoMapperProfiles.v2;

public sealed class DeveloperTypeAutoMapperProfile : Profile
{
    public DeveloperTypeAutoMapperProfile()
    {
        CreateMap<KeyValuePair<string, DeveloperTypeRedisDto?>, DeveloperTypeResponse?>().ConvertUsing(static (s, _) => s.Value.IsNull()
            ? null
            : new DeveloperTypeResponse
            {
                Id = s.Key.Parse<long>(),
                Name = s.Value.Name,
                CreatedBy = s.Value.CreatedBy,
                CreatedAt = s.Value.CreatedAt,
                UpdatedBy = s.Value.UpdatedBy,
                UpdatedAt = s.Value.UpdatedAt,
                IsActive = s.Value.IsActive
            });

        _ = CreateMap<DeveloperType, DeveloperTypeRedisDto>();

        _ = CreateMap<DeveloperType, DeveloperTypeResponse>();

        _ = CreateMap<(long Id, DeveloperTypeRedisDto Dto), DeveloperTypeResponse>()
            .ForMember(static d => d.Id, static o => o.MapFrom(static s => s.Id))
            .ForMember(static d => d.Name, static o => o.MapFrom(static s => s.Dto.Name))
            .ForMember(static d => d.CreatedBy, static o => o.MapFrom(static s => s.Dto.CreatedBy))
            .ForMember(static d => d.CreatedAt, static o => o.MapFrom(static s => s.Dto.CreatedAt))
            .ForMember(static d => d.UpdatedBy, static o => o.MapFrom(static s => s.Dto.UpdatedBy))
            .ForMember(static d => d.UpdatedAt, static o => o.MapFrom(static s => s.Dto.UpdatedAt))
            .ForMember(static d => d.IsActive, static o => o.MapFrom(static s => s.Dto.IsActive));

        _ = CreateMap<DeveloperTypeCreateRequest, DeveloperType>()
            .ForMember(static d => d.CreatedAt, static o => o.MapFrom(static s => UtcNow))
            .ForMember(static d => d.IsActive, static o => o.MapFrom(static s => true))
            .ForMember(static d => d.IsDeleted, static o => o.MapFrom(static s => false))
            .Ignore(static d => d.Id)
            .Ignore(static d => d.UpdatedBy)
            .Ignore(static d => d.UpdatedAt);

        _ = CreateMap<(long Id, DeveloperTypeUpdateRequest Request), DeveloperTypeDto>()
            .ForMember(static d => d.Id, static o => o.MapFrom(static s => s.Id))
            .ForMember(static d => d.Name, static o => o.MapFrom(static s => s.Request.Name))
            .ForMember(static d => d.UpdatedBy, static o => o.MapFrom(static s => s.Request.UpdatedBy))
            .ForMember(static d => d.IsActive, static o => o.MapFrom(static s => s.Request.IsActive))
            .Ignore(static d => d.IsDeleted);

        _ = CreateMap<(Guid Id, string UpdatedBy), DeveloperTypeDto>()
            .ForMember(static d => d.Id, static o => o.MapFrom(static s => s.Id))
            .ForMember(static d => d.UpdatedBy, static o => o.MapFrom(static s => s.UpdatedBy))
            .Ignore(static d => d.Name)
            .Ignore(static d => d.IsActive)
            .Ignore(static d => d.IsDeleted);
    }
}
