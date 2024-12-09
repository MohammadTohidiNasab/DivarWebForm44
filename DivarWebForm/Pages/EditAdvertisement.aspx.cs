using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DivarWebForm.Pages
{
    public partial class EditAdvertisement : System.Web.UI.Page
    {
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
                    string query = "SELECT Title, Content, Price, Category FROM Advertisements WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Title.Text = reader["Title"].ToString();
                        Content.Text = reader["Content"].ToString();
                        Price.Text = reader["Price"].ToString();
                        Category.SelectedValue = reader["Category"].ToString();
                    }
                }
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(id))
            {
                string title = Title.Text;
                string content = Content.Text;
                int price = int.Parse(Price.Text);
                int category = int.Parse(Category.SelectedValue);

                string connectionString = ConfigurationManager.ConnectionStrings["DivarConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Advertisements SET Title = @Title, Content = @Content, Price = @Price, Category = @Category WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Content", content);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Category", category);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }

                // بازگشت به صفحه جزئیات آگهی یا صفحه موفقیت
                Response.Redirect("Details.aspx?id=" + id);
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // بازگشت به صفحه جزئیات آگهی
            Response.Redirect("Details.aspx?id=" + Request.QueryString["id"]);
        }
    }
}
