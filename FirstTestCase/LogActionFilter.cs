using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Diagnostics;
using System.IO;


namespace FirstTestCase.ActionFilters
{
    public class LogActionFilter : ActionFilterAttribute

    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Headers.Add("Start", DateTime.Now.ToString());
            Log("GetRequest", filterContext.RouteData);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Headers.Add("Stop", DateTime.Now.ToString());
            Log("GetResponse", filterContext.RouteData);
        }

        private void Log(string methodName, RouteData routeData)
        {
            string path = "LogsFilters.txt";
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("DateTime:{0} Method:{1} controller:{2} action:{3}", DateTime.Now.ToString(), methodName, controllerName, actionName);
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                 writer.WriteLine(message);

            }
        }

    }
}