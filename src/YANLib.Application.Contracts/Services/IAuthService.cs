using System.Threading.Tasks;

namespace YANLib.Services;

public interface IAuthService
{
    public Task<string?> GenerateToken(string username, string password);
}
