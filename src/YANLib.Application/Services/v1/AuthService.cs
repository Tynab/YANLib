using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YANLib.Core;
using YANLib.Dtos;
using static Microsoft.IdentityModel.Tokens.SecurityAlgorithms;
using static System.DateTime;
using static System.Guid;
using static System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;
using static System.IO.File;
using static System.Security.Claims.ClaimTypes;
using static System.Text.Encoding;

namespace YANLib.Services.v1;

public class AuthService(ILogger<AuthService> logger, IConfiguration configuration) : YANLibAppService, IAuthService
{
    private readonly ILogger<AuthService> _logger = logger;
    private readonly IConfiguration _configuration = configuration;

    public async ValueTask<string?> GenerateToken(string username, string password)
    {
        try
        {
            var filePath = "Dummy/accounts.js";

            if (!Exists(filePath))
            {
                _logger.LogWarning("File not found: {Path}", filePath);

                return default;
            }

            var user = (await ReadAllTextAsync(filePath))?.Deserialize<List<UserDto>>()?.FirstOrDefault(x => x.UserName == username && x.PassWord == password);

            if (user.IsNull())
            {
                return default;
            }

            var claims = new List<Claim>
            {
                new(Sub, user.UserId.ToString()),
                new(UniqueName, username),
                new(Jti, NewGuid().ToString())
            };

            claims.AddRange(user.Roles?.Select(role => new Claim(Role, role.RoleName ?? string.Empty)) ?? []);

            return new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: UtcNow.AddHours(1),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(UTF8.GetBytes(_configuration.GetSection("Jwt:Secret")?.Value ?? string.Empty)), HmacSha256)
            ));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GenerateToken-AuthService-Exception: {Username} - {Password}", username, password);

            throw;
        }
    }
}
