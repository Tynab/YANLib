using AutoMapper;
using Volo.Abp.Application.Dtos;
using YANLib.RabbitMq.Etos;
using YANLib.Requests;

namespace YANLib;

public class YANLibApplicationAutoMapperProfile : Profile
{
    public YANLibApplicationAutoMapperProfile()
    {
        _ = CreateMap<(byte PageNumber, byte PageSize), PagedAndSortedResultRequestDto>()
            .ForMember(static d => d.SkipCount, static o => o.MapFrom(static s => (s.PageNumber - 1) * s.PageSize))
            .ForMember(static d => d.MaxResultCount, static o => o.MapFrom(static s => s.PageSize));

        _ = CreateMap<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>()
            .ForMember(static d => d.SkipCount, static o => o.MapFrom(static s => (s.PageNumber - 1) * s.PageSize))
            .ForMember(static d => d.MaxResultCount, static o => o.MapFrom(static s => s.PageSize))
            .ForMember(static d => d.Sorting, static o => o.MapFrom(static s => s.Sorting));

        _ = CreateMap(typeof(PagedResultDto<>), typeof(PagedResultDto<>));

        _ = CreateMap<NotificationRequest, NotificationEto>();
    }
}
