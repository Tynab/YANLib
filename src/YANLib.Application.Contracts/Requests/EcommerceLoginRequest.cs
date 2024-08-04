using System.ComponentModel;

namespace YANLib.Requests;

public sealed class EcommerceLoginRequest
{
    [DefaultValue("nguyenvana@gmail.com")]
    public required string Username { get; set; } = "nguyenvana@gmail.com";

    [DefaultValue("nguyenvana")]
    public required string Password { get; set; } = "nguyenvana";
}
