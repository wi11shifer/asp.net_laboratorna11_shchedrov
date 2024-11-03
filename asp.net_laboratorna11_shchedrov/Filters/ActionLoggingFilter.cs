using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace asp.net_laboratorna11_shchedrov.Filters
{
    public class ActionLoggingFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var methodName = context.ActionDescriptor.DisplayName;
            var time = DateTime.Now;

            using (var writer = new StreamWriter("action_log.txt", true))
            {
                writer.WriteLine($"Method: {methodName}, Time: {time}");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
