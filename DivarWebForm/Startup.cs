using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(DivarWebForm.Startup))]

namespace DivarWebForm
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // پیکربندی OWIN و Identity
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Pages/Login.aspx")
            });
        }
    }
}
