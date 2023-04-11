using System;
using System.Collections.Generic;
using System.Text;
using YANLib.Localization;
using Volo.Abp.Application.Services;

namespace YANLib;

/* Inherit your application services from this class.
 */
public abstract class YANLibAppService : ApplicationService
{
    protected YANLibAppService()
    {
        LocalizationResource = typeof(YANLibResource);
    }
}
