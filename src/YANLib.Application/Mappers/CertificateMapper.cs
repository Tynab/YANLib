namespace YANLib.Mappers;

public sealed class CertificateMapper : Profile
{
    public CertificateMapper()
    {
        _ = CreateMap<CertificateAdjustEto, CertificateRequest>();

        _ = CreateMap<CertificateRequest, Certificate>()
            .Ignore(d => d.CreatedAt)
            .Ignore(d => d.UpdatedAt);

        _ = CreateMap<Certificate, CertificateCreateEto>();

        _ = CreateMap<Certificate, CertificateResponse>();

        _ = CreateMap<CertificateResponse, CertificateAdjustEto>();

        _ = CreateMap<CertificateCreateEto, CertificateRequest>();
    }
}
