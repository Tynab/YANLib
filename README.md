# YAMI AN NEPHILIM LIBRARY
YANLib is based on .NET 6.0 (LTS)

### INSTALL
https://www.nuget.org/packages/Tynab.YANLib
```
PM> NuGet\Install-Package Tynab.YANLib
```

## MASK
<p align="center">
<img src="https://github.com/Tynab/YANLib/blob/main/pic/0.jpg"></img>
</p>

## CODE DEMO
```c#
// Import
using System.Collections.Generic;
using static System.Guid;
using static YANLib.YANBool;
using static YANLib.YANNum;
using static YANLib.YANText;

// Generate data
private static IEnumerable<string> GenData(byte quantity)
{
    for (var i = 0; i < quantity; i++)
    {
        yield return i % 2 is 0
            ? new JsonTestDto
            {
                Id = NewGuid(),
                Name = $"nguyễn văn {GenerateRandomCharacter()}".ToTitle(),
                Income = GenerateRandomUshort(),
                IsRisk = GenerateRandomBool()
            }.SerializeCamel()
            : new JsonTestDto
            {
                Id = NewGuid(),
                Name = $"đoàn thị {GenerateRandomCharacter()}".ToTitle(),
                Income = GenerateRandomUshort(),
                IsRisk = GenerateRandomBool()
            }.Serialize();
    }
}
```

### EXTENSION
- Numeric
- Text
- Bool
- DateTime
- Nullable
- Model
- JSON
- Enumerable
- Random
- Process
- Task
- Func

### OTHER
- Password

[See wiki for more details](https://github.com/Tynab/YANLib/wiki)