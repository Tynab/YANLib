using System.ComponentModel;

namespace YANLib.Requests;

public sealed class UserLoginRequest
{
    [DefaultValue("OtherUser")]
    public required string UserName { get; set; }

    [DefaultValue("user@123")]
    public required string Password { get; set; }
}
