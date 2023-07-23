using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YANLib.Models;

namespace YANLib.Repositories;

public sealed class DeveloperRepository : IDeveloperRepository
{
    public ValueTask<IEnumerable<Developer>> GetAll() => throw new NotImplementedException();
    public ValueTask<Developer> Insert(Developer entity) => throw new NotImplementedException();
    public ValueTask<Developer> Update(Developer entity) => throw new NotImplementedException();
}
