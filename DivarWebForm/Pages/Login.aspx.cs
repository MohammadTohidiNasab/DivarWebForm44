using DivarWebForm.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Web;
using System.Web.UI;

namespace DivarWebForm.Pages
{
    public partial class Login : Page
    {
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = userManager.Find(Email.Text, Password.Text);
            if (user != null)
            {
                // ورود موفق
                SignIn(userManager, user);
                // ذخیره شناسه کاربر در سشن
                Session["UserId"] = user.Id;
                Session["UserFirstName"] = user.FirstName;
                Response.Redirect("~/Pages/Default.aspx"); // هدایت به صفحه Default.aspx
            }
            else
            {
                // نمایش پیام خطا (اختیاری)
                // ErrorMessage.Text = "ورود ناموفق. لطفاً اطلاعات خود را بررسی کنید.";
                // ErrorMessage.Visible = true;
            }
        }

        private void SignIn(UserManager<ApplicationUser> manager, ApplicationUser user)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties() { IsPersistent = false }, userIdentity);
        }
    }
}
