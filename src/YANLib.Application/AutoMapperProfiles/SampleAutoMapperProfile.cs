using AutoMapper;
using Volo.Abp.AutoMapper;
using YANLib;
using YANLib.Entities;
using YANLib.EsIndices;
using YANLib.Etos;
using YANLib.RedisDtos;
using YANLib.Requests;
using YANLib.Requests.CreateOrUpdateRequest;
using YANLib.Responses;
using static System.DateTime;
using static System.Guid;

namespace YANLib.AutoMapperProfiles;

public sealed class SampleAutoMapperProfile : Profile
{
    public SampleAutoMapperProfile()
    {
        _ = CreateMap<SampleCreateOrUpdateRequest, Sample>()
            .ForMember(static d => d.Id, static o => o.MapFrom(static s => NewGuid()))
            .ForMember(static d => d.CreatedAt, static o => o.MapFrom(static s => UtcNow))
            .ForMember(static d => d.UpdatedAt, static o => o.MapFrom(static s => UtcNow))
            .ForMember(static d => d.IsActive, static o => o.MapFrom(static s => true))
            .ForMember(static d => d.IsDeleted, static o => o.MapFrom(static s => false))
            .Ignore(static d => d.CreatedBy)
            .Ignore(static d => d.UpdatedBy);

        _ = CreateMap<Sample, SampleResponse>();

        CreateMap<KeyValuePair<string, SampleRedisDto?>, SampleResponse?>().ConvertUsing(static (s, _) => s.Value.IsNull()
            ? null
            : new SampleResponse
            {
                Id = s.Key.Parse<Guid>(),
                Name = s.Value.Name,
                Description = s.Value.Description,
                Type = s.Value.Type,
                CreatedBy = s.Value.CreatedBy,
                CreatedAt = s.Value.CreatedAt,
                UpdatedBy = s.Value.UpdatedBy,
                UpdatedAt = s.Value.UpdatedAt,
                IsActive = s.Value.IsActive
            });

        _ = CreateMap<Sample, SampleRedisDto>();

        _ = CreateMap<(Guid Id, SampleRedisDto Dto), SampleResponse>()
            .ForMember(static d => d.Id, static o => o.MapFrom(static s => s.Id))
            .ForMember(static d => d.Name, static o => o.MapFrom(static s => s.Dto.Name))
            .ForMember(static d => d.Description, static o => o.MapFrom(static s => s.Dto.Description))
            .ForMember(static d => d.Type, static o => o.MapFrom(static s => s.Dto.Type))
            .ForMember(static d => d.CreatedBy, static o => o.MapFrom(static s => s.Dto.CreatedBy))
            .ForMember(static d => d.CreatedAt, static o => o.MapFrom(static s => s.Dto.CreatedAt))
            .ForMember(static d => d.UpdatedBy, static o => o.MapFrom(static s => s.Dto.UpdatedBy))
            .ForMember(static d => d.UpdatedAt, static o => o.MapFrom(static s => s.Dto.UpdatedAt))
            .ForMember(static d => d.IsActive, static o => o.MapFrom(static s => s.Dto.IsActive));

        _ = CreateMap<(Guid Id, SampleRedisDto Dto), Sample>()
            .ForMember(static d => d.Id, static o => o.MapFrom(static s => s.Id))
            .ForMember(static d => d.Name, static o => o.MapFrom(static s => s.Dto.Name))
            .ForMember(static d => d.Description, static o => o.MapFrom(static s => s.Dto.Description))
            .ForMember(static d => d.Type, static o => o.MapFrom(static s => s.Dto.Type))
            .ForMember(static d => d.CreatedBy, static o => o.MapFrom(static s => s.Dto.CreatedBy))
            .ForMember(static d => d.CreatedAt, static o => o.MapFrom(static s => s.Dto.CreatedAt))
            .ForMember(static d => d.UpdatedBy, static o => o.MapFrom(static s => s.Dto.UpdatedBy))
            .ForMember(static d => d.UpdatedAt, static o => o.MapFrom(static s => s.Dto.UpdatedAt))
            .ForMember(static d => d.IsActive, static o => o.MapFrom(static s => s.Dto.IsActive))
            .Ignore(static d => d.IsDeleted);

        _ = CreateMap<Sample, SampleEsIndex>();

        _ = CreateMap<SampleEsIndex, SampleResponse>();

        _ = CreateMap<SampleRequest, SampleEto>();
    }
}
