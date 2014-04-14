using System.Web;
using System.Web.Http;
using DhammaTalks.Api.App_Start;

namespace DhammaTalks.Api
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();

            // Add these two lines to initialize Routes and Filters:
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}