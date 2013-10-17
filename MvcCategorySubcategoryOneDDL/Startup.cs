using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcCategorySubcategoryOneDDL.Startup))]
namespace MvcCategorySubcategoryOneDDL
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
