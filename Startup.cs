using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SearchFunctionalityWithJquery.Startup))]
namespace SearchFunctionalityWithJquery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
