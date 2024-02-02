namespace YANLib.Requests;

public sealed class EcommerceLoginRequest
{
    public required string Username { get; set; }

    public required string Password { get; set; }
}
