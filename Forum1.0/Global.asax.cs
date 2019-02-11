using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DataAccessLayer.Contexts;
using System.Data.Entity;
using DataAccessLayer.Migrations;

namespace Forum1._0
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ForumDbContext, Configuration>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
