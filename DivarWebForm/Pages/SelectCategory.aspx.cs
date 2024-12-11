using System;
using System.Web.UI;
using System.Web.UI.WebControls; // اضافه کردن این خط برای استفاده از کلاس Button



namespace DivarWebForm.Pages
{
    public partial class SelectCategory : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void SelectCategoryButton_Click(object sender, EventArgs e)
        {
            string selectedCategory = (sender as Button).CommandArgument;
            Session["SelectedCategory"] = selectedCategory;

            // انتقال کاربر به صفحه ثبت آگهی
            Response.Redirect("AddAdvertisement.aspx");
        }
    }
}
