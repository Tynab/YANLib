using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YANLib.Requests;

public sealed record EcommerceLoginRequest
(
    [Required]
    [DefaultValue("nguyenvana@gmail.com")]
    string Username = "nguyenvana@gmail.com",

    [Required]
    [DefaultValue("nguyenvana")]
    string Password = "nguyenvana"
);
