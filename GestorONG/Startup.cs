using Microsoft.Owin;
using Owin;
using GestorONG.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly : OwinStartupAttribute(typeof(GestorONG.Startup))]
namespace GestorONG
{
    public partial class Startup
    {
        #region PUBLIC_MEMBER_METHODS
        /// <summary>
        /// Initial configuration of application.
        /// </summary>
        /// <param name="app">App builder object used to configure it.</param>
        public void Configuration(IAppBuilder app)
        {
            //Configure authentication properties
            ConfigureAuth(app);         
        }

        #endregion
    }
}