using System;
using System.Data.SqlClient;
using System.Configuration;

namespace DivarWebForm.Pages
{
    public partial class Details : System.Web.UI.Page
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
                    string query = "SELECT Title, Content, Price, CreatedDate, Category FROM Advertisements WHERE Id = @Id";
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
    }
}
