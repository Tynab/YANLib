using AutoMapper;
using Volo.Abp.AutoMapper;
using YANLib.Entities;
using YANLib.Kafka.Etos;
using YANLib.RabbitMq.Etos;
using YANLib.Requests.Insert;
using YANLib.Responses;

namespace YANLib.AutoMapperProfiles;

public sealed class CertificateAutoMapperProfile : Profile
{
    public CertificateAutoMapperProfile()
    {
        _ = CreateMap<CertificateAdjustEto, CertificateInsertRequest>();

        _ = CreateMap<CertificateInsertRequest, Certificate>()
            .Ignore(d => d.CreatedAt)
            .Ignore(d => d.UpdatedAt);

        _ = CreateMap<Certificate, CertificateCreateEto>();

        _ = CreateMap<Certificate, CertificateResponse>();

        _ = CreateMap<CertificateResponse, CertificateAdjustEto>();

        _ = CreateMap<CertificateCreateEto, CertificateInsertRequest>();
    }
}
