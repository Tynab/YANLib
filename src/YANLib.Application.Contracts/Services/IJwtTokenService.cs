using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YANLib.Services;

public interface IJwtTokenService
{
    public ValueTask<string?> GenerateToken(string username, string password);
}
