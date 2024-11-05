using Microsoft.AspNetCore.Mvc.Filters;

namespace Gestor_Api.Fliters
{
    public class MyLogging : Attribute, IActionFilter
    {
        private readonly string _callerName;

        public MyLogging(string callerName)
        {
            _callerName = callerName;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"Sync - Filter Executed After {_callerName}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"Sync - Filter Executed before {_callerName}");
        }
    }
}
