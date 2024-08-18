using AutoMapper;
using Volo.Abp.AutoMapper;
using YANLib.Entities;
using YANLib.Kafka.Etos;
using YANLib.RabbitMq.Etos;
using YANLib.Requests.Crud.Create;
using YANLib.Requests.Crud.Update;
using YANLib.Requests.Insert;
using YANLib.Responses;

namespace YANLib.AutoMapperProfiles;

public sealed class CertificateAutoMapperProfile : Profile
{
    public CertificateAutoMapperProfile()
    {
        _ = CreateMap<CertificateCreateRequest, Certificate>()
            .Ignore(d => d.UpdatedBy)
            .Ignore(d => d.UpdatedAt);

        _ = CreateMap<CertificateUpdateRequest, Certificate>();

        _ = CreateMap<Certificate, CertificateResponse>();

        //

        _ = CreateMap<CertificateInsertRequest, Certificate>()
            .Ignore(d => d.CreatedAt)
            .Ignore(d => d.UpdatedAt);

        _ = CreateMap<Certificate, CertificateCreateEto>();

        _ = CreateMap<Certificate, CertificateResponse>();

        _ = CreateMap<CertificateResponse, NotificationEto>();

        _ = CreateMap<CertificateCreateEto, CertificateInsertRequest>();
    }
}
