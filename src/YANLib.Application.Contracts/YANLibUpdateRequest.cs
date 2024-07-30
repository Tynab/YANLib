using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YANLib;

public class YANLibUpdateRequest
{
    public Guid UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }
}
