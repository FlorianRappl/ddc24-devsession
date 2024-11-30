using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;

namespace Search;

public static class QueryExtensions
{
    public static void GetSearchQuery(this NavigationManager navManager, out string q)
    {
        if (QueryHelpers.ParseQuery(navManager.ToAbsoluteUri(navManager.Uri).Query).TryGetValue("q", out var value))
        {
            q = value!;
        }
        else
        {
            q = string.Empty;
        }
    }
}
