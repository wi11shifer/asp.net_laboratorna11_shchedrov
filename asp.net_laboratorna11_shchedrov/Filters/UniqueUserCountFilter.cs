using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace asp.net_laboratorna11_shchedrov.Filters
{
    public class UniqueUserCountFilter : IActionFilter
    {
        private static HashSet<string> uniqueUsers = new HashSet<string>();

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var userIp = context.HttpContext.Connection.RemoteIpAddress.ToString();
            uniqueUsers.Add(userIp);

            using (var writer = new StreamWriter("unique_users_log.txt", true))
            {
                writer.WriteLine($"Unique User Count: {uniqueUsers.Count}");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
