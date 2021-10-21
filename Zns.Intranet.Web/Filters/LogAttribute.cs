using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using log4net;

namespace Zns.Intranet.Web.Filters
{
    public class LogAttribute : ActionFilterAttribute
    {
        ILog log = log4net.LogManager.GetLogger("LogAttribute");
        //
        // Summary:
        // Called by the ASP.NET MVC framework after the action method executes.
        //
        // Parameters:
        // filterContext:
        // The filter context.
         public override void OnActionExecuted(ActionExecutedContext filterContext)
           {
            Log("OnActionExecuted", filterContext.RouteData);
           }
            //
            // Summary:
            // Called by the ASP.NET MVC framework before the action method executes.
            //
            // Parameters:
            // filterContext:
            // The filter context.
             public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
              Log("OnActionExecuted", filterContext.RouteData);
            }
            //
            // Summary:
            // Called by the ASP.NET MVC framework after the action result executes.
            //
            // Parameters:
            // filterContext:
            // The filter context.
            public override void OnResultExecuted(ResultExecutedContext filterContext)
            {
                Log("OnActionExecuted", filterContext.RouteData);
            }
            //
            // Summary:
            // Called by the ASP.NET MVC framework before the action result executes.
            //
            // Parameters:
            // filterContext:
            // The filter context.
            public override void OnResultExecuting(ResultExecutingContext filterContext)
            {
                Log("OnActionExecuted", filterContext.RouteData);
            }

            private void Log(string methodName,RouteData routeData)
        {
             var logMessage = $" {routeData.Values["Controller"]},{routeData.Values["action"]}, This is simple Example.";
             log.Info(logMessage);
        }
        }
        }