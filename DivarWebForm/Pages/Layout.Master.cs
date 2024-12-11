using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using DivarWebForm.Models; // اضافه کردن فضای نام مناسب برای CategoryType

namespace DivarWebForm.Pages
{
    public partial class Layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
                SetLoginLogoutLinks();
            }
        }

        private void LoadCategories()
        {
            var categories = Enum.GetValues(typeof(CategoryType))
                                .Cast<CategoryType>()
                                .Select(c => new { Value = (int)c, Name = c.ToString() })
                                .ToList();

            CategoryRepeater.DataSource = categories;
            CategoryRepeater.DataBind();
        }

        private void SetLoginLogoutLinks()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                // کاربر لاگین است، لینک خروج را نمایش دهید
                LoginPlaceholder.Controls.Add(new Literal
                {
                    Text = "<li><a href='Logout.aspx'>خروج از حساب</a></li>"
                });
            }
            else
            {
                // کاربر لاگین نیست، لینک ورود را نمایش دهید
                LoginPlaceholder.Controls.Add(new Literal
                {
                    Text = "<li><a href='Login.aspx'>ورود به حساب</a></li>"
                });
            }
        }
    }
}
