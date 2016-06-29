using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AZURE_BLOBS.Startup))]
namespace AZURE_BLOBS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
