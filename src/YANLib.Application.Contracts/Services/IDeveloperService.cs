﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using YANLib.Requests;
using YANLib.Responses;

namespace YANLib.Services;

public interface IDeveloperService : IApplicationService
{
    public ValueTask<DeveloperResponse> Get(string id);
    public ValueTask<DeveloperResponse> Insert(DeveloperRequest request);
    public ValueTask<DeveloperResponse> Adjust(string idCard, DeveloperAdjustRequest request);
    public ValueTask<DeveloperResponse> GetByIdCard(string idCard);
    public ValueTask<List<DeveloperResponse>> GetByPhone(string phone);
    public ValueTask<List<DeveloperResponse>> SearchByPhone(string searchText);
    public ValueTask<bool> SyncDbToEs();
}
