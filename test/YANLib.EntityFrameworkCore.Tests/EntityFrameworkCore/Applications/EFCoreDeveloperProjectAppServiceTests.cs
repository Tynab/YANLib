using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using YANLib.Services;

namespace YANLib.EntityFrameworkCore.Applications;

[Collection(YANLibTestConsts.CollectionDefinitionName)]
public class EFCoreDeveloperProjectAppServiceTests : DeveloperProjectAppServiceTests<YANLibEntityFrameworkCoreTestModule> { }
