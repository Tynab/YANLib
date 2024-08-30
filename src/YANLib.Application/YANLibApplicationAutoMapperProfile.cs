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
            .ForMember(d => d.SkipCount, o => o.MapFrom(s => (s.PageNumber - 1) * s.PageSize))
            .ForMember(d => d.MaxResultCount, o => o.MapFrom(s => s.PageSize));

        _ = CreateMap<(byte PageNumber, byte PageSize, string Sorting), PagedAndSortedResultRequestDto>()
            .ForMember(d => d.SkipCount, o => o.MapFrom(s => (s.PageNumber - 1) * s.PageSize))
            .ForMember(d => d.MaxResultCount, o => o.MapFrom(s => s.PageSize))
            .ForMember(d => d.Sorting, o => o.MapFrom(s => s.Sorting));

        _ = CreateMap<NotificationRequest, NotificationEto>();
    }
}
