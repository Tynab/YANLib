using AutoMapper;
using System;
using Volo.Abp.AutoMapper;
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.EsIndices;
using YANLib.Kafka.Etos;
using YANLib.RabbitMq.Etos;
using YANLib.Requests.Crud.Create;
using YANLib.Requests.Crud.Update;
using YANLib.Requests.Insert;
using YANLib.Requests.Modify;
using YANLib.Responses;
using static System.DateTime;

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

        _ = CreateMap<(string Code, CertificateInsertRequest Request), Certificate>()
            .ForMember(d => d.Code, o => o.MapFrom(s => s.Code))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Request.Name))
            .ForMember(d => d.GPA, o => o.MapFrom(s => s.Request.GPA))
            .ForMember(d => d.DeveloperId, o => o.MapFrom(s => s.Request.DeveloperId))
            .ForMember(d => d.CreatedBy, o => o.MapFrom(s => s.Request.CreatedBy))
            .ForMember(d => d.CreatedAt, o => o.MapFrom(s => UtcNow))
            .ForMember(d => d.IsActive, o => o.MapFrom(s => true))
            .ForMember(d => d.IsDeleted, o => o.MapFrom(s => false))
            .Ignore(d => d.UpdatedBy)
            .Ignore(d => d.UpdatedAt);

        _ = CreateMap<(Guid Id, CertificateModifyRequest Request), CertificateDto>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Request.Name))
            .ForMember(d => d.GPA, o => o.MapFrom(s => s.Request.GPA))
            .ForMember(d => d.DeveloperId, o => o.MapFrom(s => s.Request.DeveloperId))
            .ForMember(d => d.UpdatedBy, o => o.MapFrom(s => s.Request.UpdatedBy))
            .ForMember(d => d.IsActive, o => o.MapFrom(s => s.Request.IsActive))
            .ForMember(d => d.IsDeleted, o => o.MapFrom(s => false));

        _ = CreateMap<Certificate, CertificateEsIndex>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Code))
            .ForMember(d => d.CertificateId, o => o.MapFrom(s => s.Id));

        _ = CreateMap<Certificate, CertificateResponse>();
    }
}
