using DivarWebForm.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Web.UI;

namespace DivarWebForm.Pages
{
    public partial class Register : Page
    {
        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = new ApplicationUser
            {
                UserName = Email.Text,
                Email = Email.Text,
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                PhoneNumber = PhoneNumber.Text
            };
            var result = userManager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // هدایت به صفحه Default.aspx
                Response.Redirect("~/Pages/Default.aspx");
            }
            else
            {
                // نمایش پیام خطا
            }
        }
    }
}
