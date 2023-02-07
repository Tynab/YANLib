using System.Collections;

namespace YANLib;

public static partial class YANModel
{
    /// <summary>
    /// Change date time value by different time zone for all <see cref="DateTime"/> properties in parent model, child model and list child model.
    /// </summary>
    /// <typeparam name="T">Class model.</typeparam>
    /// <param name="mdl">Input model.</param>
    /// <param name="tzSrc">Time zone source.</param>
    /// <param name="tzDst">Time zone destination.</param>
    /// <returns>Model with date time changed.</returns>
    public static T ChangeTimeZoneAllProperties<T>(this T mdl, int tzSrc, int tzDst)
    {
        if (mdl != null)
        {
            var props = mdl.GetType().GetProperties();
            foreach (var prop in props)
            {
                var propType = prop.PropertyType;
                if (propType == typeof(DateTime?))
                {
                    prop.SetValue(mdl, ((DateTime?)prop.GetValue(mdl, null)).ChangeTimeZone(tzSrc, tzDst), null);
                }
                else if (propType == typeof(DateTime))
                {
                    var val = prop.GetValue(mdl, null);
                    if (val != null)
                    {
                        prop.SetValue(mdl, ((DateTime)val).ChangeTimeZone(tzSrc, tzDst), null);
                    }
                }
                else if (propType.Namespace != null && !propType.Namespace.StartsWith("System"))
                {
                    prop.GetValue(mdl, null).ChangeTimeZoneAllProperties(tzSrc, tzDst);
                }
                else if (propType.IsGenericType && prop.GetValue(mdl, null) is IList list)
                {
                    foreach (var item in list)
                    {
                        item.ChangeTimeZoneAllProperties(tzSrc, tzDst);
                    }
                }
            }
        }
        return mdl;
    }
}
