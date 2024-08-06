using AutoMapper;
using YANLib.RabbitMq.Etos;
using YANLib.Requests;

namespace YANLib.AutoMapperProfiles;

public class YANLibApplicationAutoMapperProfile : Profile
{
    public YANLibApplicationAutoMapperProfile() => CreateMap<NotificationRequest, NotificationEto>();
}
