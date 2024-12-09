using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

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
                    string query = "SELECT Title, Content, Price, CreatedDate, Category, ImageUrl, ImageUrl2, ImageUrl3 FROM Advertisements WHERE Id = @Id";
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

                        // اضافه کردن تصاویر به اسلایدر
                        AddImageToCarousel(reader["ImageUrl"].ToString(), true);
                        AddImageToCarousel(reader["ImageUrl2"].ToString(), false);
                        AddImageToCarousel(reader["ImageUrl3"].ToString(), false);
                    }
                }
            }
        }

        private void AddImageToCarousel(string imageUrl, bool isActive)
        {
            if (!string.IsNullOrEmpty(imageUrl))
            {
                var imageHtml = $@"
                    <div class='carousel-item{(isActive ? " active" : string.Empty)}'>
                        <img src='{imageUrl}' class='d-block w-100 article-image' alt='{imageUrl}' loading='lazy'>
                    </div>";

                ImageCarouselPlaceholder.Controls.Add(new Literal { Text = imageHtml });
            }
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditAdvertisement.aspx?id=" + Request.QueryString["id"]);
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteAdvertisement.aspx?id=" + Request.QueryString["id"]);
        }
    }
}
