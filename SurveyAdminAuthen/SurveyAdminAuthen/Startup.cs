using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SurveyAdminAuthen.Startup))]
namespace SurveyAdminAuthen
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
