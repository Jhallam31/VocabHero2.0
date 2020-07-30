using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VocabHero3.Startup))]
namespace VocabHero3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
