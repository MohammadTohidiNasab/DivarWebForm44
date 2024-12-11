using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using DivarWebForm.Models;

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
                    string query = @"
                        SELECT a.Title, a.Content, a.Price, a.CreatedDate, a.Category, a.ImageUrl, a.ImageUrl2, a.ImageUrl3, a.UserId, u.FirstName, u.LastName, u.PhoneNumber
                        FROM Advertisements a
                        JOIN AspNetUsers u ON a.UserId = u.Id
                        WHERE a.Id = @Id";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        TitleLiteral.Text = reader["Title"].ToString();
                        ContentLiteral.Text = reader["Content"].ToString();
                        PriceLiteral.Text = reader["Price"].ToString();
                        CategoryLiteral.Text = ((CategoryType)Convert.ToInt32(reader["Category"])).ToString();
                        CreatedDateLiteral.Text = reader["CreatedDate"].ToString();

                        // نمایش نام و نام خانوادگی و شماره تلفن کاربر
                        FullNameLiteral.Text = $"{reader["FirstName"]} {reader["LastName"]}";
                        PhoneNumberLiteral.Text = reader["PhoneNumber"].ToString();

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
