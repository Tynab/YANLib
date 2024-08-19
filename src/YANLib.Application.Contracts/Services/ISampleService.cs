using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace YANLib.Services;

public interface ISampleService : IApplicationService
{
    public ValueTask<string> JsonTest(uint quantity, bool hideSystem);
}
