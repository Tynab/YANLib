using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace YANLib.Services;

public interface IYANJsonService : IApplicationService
{
    public ValueTask<string> DuoVsStandard(uint quantity);
}
