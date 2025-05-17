using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace YANLib.Services;

public interface ISampleService : IApplicationService
{
    public Task<string> Test(uint quantity, bool hideSystem);
}
