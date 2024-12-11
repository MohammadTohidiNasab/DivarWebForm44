using System;
using System.Web;
using System.Web.UI;

namespace DivarWebForm.Pages
{
    public partial class Logout : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                // پاک کردن سشن‌های کاربر
                Session.Clear();
                Session.Abandon();
                // لاگ اوت کاربر
                HttpContext.Current.GetOwinContext().Authentication.SignOut();
            }

            // هدایت به صفحه‌ی لاگین با تاخیر
            Response.Redirect("Default.aspx");
        }
    }
}
