using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace DivarWebForm.Pages
{
    public partial class DeleteAdvertisement : System.Web.UI.Page
    {
        protected System.Web.UI.WebControls.Literal TitleLiteral;
        protected System.Web.UI.WebControls.Literal ContentLiteral;
        protected System.Web.UI.WebControls.Literal PriceLiteral;
        protected System.Web.UI.WebControls.Literal CategoryLiteral;
        protected System.Web.UI.WebControls.Literal CreatedDateLiteral;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAdvertisementDetails();
            }
        }

        private void LoadAdvertisementDetails()
        {
            string id = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(id))
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DivarConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Title, Content, Price, Category, CreatedDate FROM Advertisements WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        TitleLiteral.Text = reader["Title"].ToString();
                        ContentLiteral.Text = reader["Content"].ToString();
                        PriceLiteral.Text = reader["Price"].ToString();
                        CategoryLiteral.Text = reader["Category"].ToString();
                        CreatedDateLiteral.Text = reader["CreatedDate"].ToString();
                    }
                }
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(id))
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DivarConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT ImageUrl FROM Advertisements WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    string folderPath = string.Empty;
                    if (reader.Read())
                    {
                        string imageUrl = reader["ImageUrl"].ToString();
                        if (!string.IsNullOrEmpty(imageUrl))
                        {
                            folderPath = Server.MapPath("~" + Path.GetDirectoryName(imageUrl));
                        }
                    }
                    reader.Close();

                    // حذف پوشه تصاویر
                    if (!string.IsNullOrEmpty(folderPath) && Directory.Exists(folderPath))
                    {
                        Directory.Delete(folderPath, true);
                    }

                    // حذف آگهی از پایگاه داده
                    string deleteQuery = "DELETE FROM Advertisements WHERE Id = @Id";
                    command = new SqlCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }

                // بازگشت به صفحه اصلی یا صفحه موفقیت
                Response.Redirect("Default.aspx");
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // بازگشت به صفحه جزئیات آگهی
            Response.Redirect("Details.aspx?id=" + Request.QueryString["id"]);
        }
    }
}
