using AutoMapper;
using Volo.Abp.AutoMapper;
using YANLib.Models;
using YANLib.Requests;
using YANLib.Responses;

namespace YANLib.Mappers;

public sealed class CertificateMapper : Profile
{
    public CertificateMapper()
    {
        _ = CreateMap<CertificateFullRequest, Certificate>()
            .Ignore(d => d.CreatedDate)
            .Ignore(d => d.ModifiedDate);

        _ = CreateMap<CertificateRequest, Certificate>()
            .Ignore(d => d.Id)
            .Ignore(d => d.CreatedDate)
            .Ignore(d => d.ModifiedDate);

        _ = CreateMap<CertificateRipRequest, Certificate>()
            .Ignore(d => d.Id)
            .Ignore(d => d.DeveloperId)
            .Ignore(d => d.CreatedDate)
            .Ignore(d => d.ModifiedDate);

        _ = CreateMap<Certificate, CertificateResponse>().ReverseMap();
    }
}
