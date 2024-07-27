using marketplace1.Context;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(marketplace1.Startup))]
namespace marketplace1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            Database.SetInitializer<ApplicationContext>(new CreateDatabaseIfNotExists<ApplicationContext>());
        }
    }
}
