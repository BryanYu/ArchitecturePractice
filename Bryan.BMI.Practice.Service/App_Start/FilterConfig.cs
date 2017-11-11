using System.Web;
using System.Web.Mvc;

namespace Bryan.BMI.Practice.Service
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
