using System;
using System.Linq;
using System.Web.UI.WebControls;
using DivarWebForm.Models; // اضافه کردن فضای نام مناسب

namespace DivarWebForm.Pages
{
    public partial class Layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
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
    }
}
