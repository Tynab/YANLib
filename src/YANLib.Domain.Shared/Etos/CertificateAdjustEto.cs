using Volo.Abp.EventBus;

namespace YANLib.Etos;

[EventName("yanlib.certificate.adjust")]
public sealed class CertificateAdjustEto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public double? GPA { get; set; }
    public string DeveloperId { get; set; }
}
