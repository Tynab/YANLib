using System.ComponentModel;

namespace YANLib.Requests;

public sealed class EcommerceLoginRequest
{
    [DefaultValue("nguyenvana@gmail.com")]
    public required string Username { get; set; }

    [DefaultValue("nguyenvana")]
    public required string Password { get; set; }
}
