using AutoMapper;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AutoMapper;
using YANLib.Dtos;
using YANLib.Entities;
using YANLib.EsIndices;
using YANLib.Requests.v1.Create;
using YANLib.Requests.v1.Update;
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

        _ = CreateMap<(string Id, Requests.v2.Create.CertificateCreateRequest Request), Certificate>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Request.Name))
            .ForMember(d => d.GPA, o => o.MapFrom(s => s.Request.GPA))
            .ForMember(d => d.CreatedBy, o => o.MapFrom(s => s.Request.CreatedBy))
            .ForMember(d => d.CreatedAt, o => o.MapFrom(s => UtcNow))
            .ForMember(d => d.IsActive, o => o.MapFrom(s => true))
            .ForMember(d => d.IsDeleted, o => o.MapFrom(s => false))
            .Ignore(d => d.UpdatedBy)
            .Ignore(d => d.UpdatedAt);

        _ = CreateMap<(string Id, Requests.v2.Update.CertificateUpdateRequest Request), CertificateDto>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            .ForMember(d => d.Name, o => o.MapFrom(s => s.Request.Name))
            .ForMember(d => d.GPA, o => o.MapFrom(s => s.Request.GPA))
            .ForMember(d => d.UpdatedBy, o => o.MapFrom(s => s.Request.UpdatedBy))
            .ForMember(d => d.IsActive, o => o.MapFrom(s => s.Request.IsActive))
            .Ignore(d => d.IsDeleted);

        _ = CreateMap<Certificate, CertificateEsIndex>();

        _ = CreateMap<CertificateEsIndex, CertificateResponse>();

        CreateMap<PagedResultDto<CertificateEsIndex>, PagedResultDto<CertificateResponse>>().ConvertUsing((source, dest, context)
            => new PagedResultDto<CertificateResponse>(source.TotalCount, context.Mapper.Map<IReadOnlyList<CertificateResponse>>(source.Items)));
    }
}
