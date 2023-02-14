using System.Collections;
using static System.Reflection.BindingFlags;

namespace YANLib;

public static partial class YANModel
{
    /// <summary>
    /// Changes the time zone of all properties of the specified model <paramref name="mdl"/>.
    /// </summary>
    /// <typeparam name="T">The type of the model.</typeparam>
    /// <param name="mdl">The model whose properties' time zones are to be changed.</param>
    /// <param name="tzSrc">The source time zone offset, in minutes.</param>
    /// <param name="tzDst">The destination time zone offset, in minutes.</param>
    /// <returns>The model with the changed time zones of its properties.</returns>
    public static T? ChangeTimeZoneAllProperties<T>(this T? mdl, int tzSrc, int tzDst) where T : class
    {
        if (mdl != null)
        {
            var props = typeof(T).GetProperties(Public | Instance).Where(p => p.CanRead && p.CanWrite);
            foreach (var prop in props)
            {
                var val = prop.GetValue(mdl);
                if (val != null)
                {
                    if (val is DateTime dt)
                    {
                        prop.SetValue(mdl, dt.ChangeTimeZone(tzSrc, tzDst));
                    }
                    else if (val.GetType().IsClass)
                    {
                        prop.SetValue(mdl, ChangeTimeZoneAllProperties(val, tzSrc, tzDst));
                    }
                    else if (val.GetType().IsGenericType && val.GetType().GetGenericTypeDefinition() == typeof(List<>))
                    {
                        var list = (IList)val;
                        for (var i = 0; i < list.Count; i++)
                        {
                            list[i] = ChangeTimeZoneAllProperties(list[i], tzSrc, tzDst);
                        }
                    }
                }
            }
        }
        return mdl;
    }
}
