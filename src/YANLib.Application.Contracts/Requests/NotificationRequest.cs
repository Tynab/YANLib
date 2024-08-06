using System;
using System.ComponentModel.DataAnnotations;

namespace YANLib.Requests;

public sealed record NotificationRequest([Required] string Message, [Required] Guid SentBy);
