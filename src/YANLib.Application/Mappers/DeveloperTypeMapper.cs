namespace YANLib.Mappers;

public sealed class DeveloperTypeMapper : Profile
{
    public DeveloperTypeMapper()
    {
        _ = CreateMap<KeyValuePair<string, DeveloperTypeRedisDto>, DeveloperTypeResponse>()
            .ForMember(d => d.Code, o => o.MapFrom(s => s.Key.ToInt(default)))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Value.Name))
            .ForMember(d => d.IsActive, o => o.MapFrom(s => s.Value.IsActive))
            .ForMember(d => d.CreatedAt, o => o.MapFrom(s => s.Value.CreatedAt))
            .ForMember(d => d.UpdatedAt, o => o.MapFrom(s => s.Value.UpdatedAt));

        _ = CreateMap<DeveloperTypeRedisDto, DeveloperTypeResponse>()
            .Ignore(d => d.Code);

        _ = CreateMap<DeveloperTypeCreateRequest, DeveloperType>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Code))
            .Ignore(d => d.CreatedAt)
            .Ignore(d => d.UpdatedAt);

        _ = CreateMap<(int, DeveloperTypeUpdateRequest), DeveloperType>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Item1))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Item2.Name))
            .ForMember(d => d.IsActive, o => o.MapFrom(s => s.Item2.IsActive))
            .Ignore(d => d.CreatedAt)
            .Ignore(d => d.UpdatedAt);

        _ = CreateMap<DeveloperType, DeveloperTypeRedisDto>();

        _ = CreateMap<DeveloperType, DeveloperTypeResponse>()
            .ForMember(d => d.Code, o => o.MapFrom(s => s.Id));

        _ = CreateMap<DeveloperTypeResponse, DeveloperType>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Code));
    }
}
