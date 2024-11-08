using System.Threading.Tasks;

namespace YANLib.Services;

public interface IAuthService
{
    public ValueTask<string?> GenerateToken(string username, string password);
}
