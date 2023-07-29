using AutoMapper;
using Volo.Abp.AutoMapper;
using YANLib.Etos;
using YANLib.Models;
using YANLib.Requests;
using YANLib.Responses;

namespace YANLib.Mappers;

public sealed class CertificateMapper : Profile
{
    public CertificateMapper()
    {
        _ = CreateMap<CertificateRipRequest, Certificate>()
            .Ignore(d => d.Id)
            .Ignore(d => d.DeveloperId)
            .Ignore(d => d.CreatedDate)
            .Ignore(d => d.ModifiedDate);

        _ = CreateMap<Certificate, CertificateResponse>().ReverseMap();

        _ = CreateMap<Certificate, CertificateCreateEto>();

        _ = CreateMap<Certificate, CertificateAdjustEto>();

        _ = CreateMap<CertificateResponse, CertificateAdjustEto>();

        _ = CreateMap<CertificateFullRequest, Certificate>()
            .Ignore(d => d.CreatedDate)
            .Ignore(d => d.ModifiedDate);

        _ = CreateMap<CertificateCreateEto, CertificateFullRequest>().ReverseMap();

        _ = CreateMap<CertificateAdjustEto, CertificateFullRequest>().ReverseMap();
    }
}
