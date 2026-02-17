using System.Web;
using System.Web.Mvc;

namespace TesteTecnicoEluminiB3.Services.Api
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
