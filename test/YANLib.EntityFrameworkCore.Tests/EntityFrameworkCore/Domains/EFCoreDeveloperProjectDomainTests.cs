using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using YANLib.Domain;

namespace YANLib.EntityFrameworkCore.Domains;

[Collection(YANLibTestConsts.CollectionDefinitionName)]
public class EFCoreDeveloperProjectDomainTests : DeveloperProjectDomainTests<YANLibEntityFrameworkCoreTestModule> { }
