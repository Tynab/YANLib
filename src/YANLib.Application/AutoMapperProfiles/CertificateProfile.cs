using AutoMapper;
using Volo.Abp.AutoMapper;
using YANLib.Entities;
using YANLib.Kafka.Etos;
using YANLib.RabbitMq.Etos;
using YANLib.Requests.Certificate;
using YANLib.Responses;

namespace YANLib.AutoMapperProfiles;

public sealed class CertificateProfile : Profile
{
    public CertificateProfile()
    {
        _ = CreateMap<CertificateAdjustEto, CertificateCreateRequest>();

        _ = CreateMap<CertificateCreateRequest, Certificate>()
            .Ignore(d => d.CreatedAt)
            .Ignore(d => d.UpdatedAt);

        _ = CreateMap<Certificate, CertificateCreateEto>();

        _ = CreateMap<Certificate, CertificateResponse>();

        _ = CreateMap<CertificateResponse, CertificateAdjustEto>();

        _ = CreateMap<CertificateCreateEto, CertificateCreateRequest>();
    }
}
