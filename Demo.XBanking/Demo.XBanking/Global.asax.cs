using Demo.XBanking.App_Start;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Rabbit.Web.Mvc.Security;

namespace Demo.XBanking
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ModelBinders.Binders.DefaultBinder = new SafeHtmlModelBinder();
        }
    }
}