using System.Threading.Tasks;

namespace YANLib.Services.v1;

public interface IAuthService
{
    public ValueTask<string?> GenerateToken(string username, string password);
}
