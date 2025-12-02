using System.ComponentModel;

namespace YANLib.Enums;

public enum SampleType
{
    [Description("Retail")]
    Retail = 942_001,

    [Description("Banking")]
    Banking = 942_002,

    [Description("Edu")]
    Edu = 942_003,

    [Description("Blockchain")]
    Blockchain = 942_004
}
