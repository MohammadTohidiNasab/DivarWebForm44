using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using DivarWebForm.Models; // اضافه کردن مرجع به فضای نام مدل‌ها

namespace DivarWebForm.Pages
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAdvertisements();
                ShowWelcomeMessage();

            }
        }


        private void ShowWelcomeMessage()
        {
            // بررسی کنیم که آیا کاربر لاگین کرده است یا خیر
            if (Session["UserFirstName"] != null)
            {
                string userFirstName = Session["UserFirstName"].ToString();
                WelcomeMessage.Text = $"<h4>خوش آمدید {userFirstName}</h4>";
            }
        }

        private void LoadAdvertisements()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DivarConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT a.Id, a.Title, a.Price, a.ImageUrl, a.Category 
                    FROM Advertisements a";

                string selectedCategory = Request.QueryString["category"];
                if (!string.IsNullOrEmpty(selectedCategory))
                {
                    query += " WHERE a.Category = @Category";
                }

                SqlCommand command = new SqlCommand(query, connection);
                if (!string.IsNullOrEmpty(selectedCategory))
                {
                    command.Parameters.AddWithValue("@Category", selectedCategory);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // افزودن ستون CategoryName به دیتاتبیل برای نگهداری نام دسته‌بندی
                dataTable.Columns.Add("CategoryName", typeof(string));

                foreach (DataRow row in dataTable.Rows)
                {
                    // تنظیم نام دسته‌بندی بر اساس مقدار ستون Category و استفاده از enum
                    row["CategoryName"] = ((CategoryType)row["Category"]).ToString();
                }

                AdsRepeater.DataSource = dataTable;
                AdsRepeater.DataBind();
            }
        }
    }
}
