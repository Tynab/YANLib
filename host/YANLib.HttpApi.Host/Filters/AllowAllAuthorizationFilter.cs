using Hangfire.Dashboard;

namespace YANLib.Filters;

public class AllowAllAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context) => true;
}
