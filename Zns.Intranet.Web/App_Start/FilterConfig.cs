using System.Web;
using System.Web.Mvc;
using Zns.Intranet.Web.Filters;

namespace Zns.Intranet.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new LogAttribute());
        }
    }
}
