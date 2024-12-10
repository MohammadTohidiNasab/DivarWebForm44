using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls; 

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
                    string query = "SELECT Title, Content, Price, ImageUrl, ImageUrl2, ImageUrl3 FROM Advertisements WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Title.Text = reader["Title"].ToString();
                        Content.Text = reader["Content"].ToString();
                        Price.Text = reader["Price"].ToString();

                        CurrentImage1.Text = Path.GetFileName(reader["ImageUrl"].ToString());
                        CurrentImage2.Text = Path.GetFileName(reader["ImageUrl2"].ToString());
                        CurrentImage3.Text = Path.GetFileName(reader["ImageUrl3"].ToString());
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

                string connectionString = ConfigurationManager.ConnectionStrings["DivarConnection"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Advertisements SET Title = @Title, Content = @Content, Price = @Price, ImageUrl = @ImageUrl, ImageUrl2 = @ImageUrl2, ImageUrl3 = @ImageUrl3 WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Content", content);
                    command.Parameters.AddWithValue("@Price", price);

                    // مسیر محلی برای ذخیره تصاویر
                    string uploadPath = Server.MapPath("~/Files/Uploads/");
                    string adFolder = Path.Combine(uploadPath, $"advertisement_{id}");
                    Directory.CreateDirectory(adFolder);

                    string imageUrl1 = SaveFile(Image1, adFolder);
                    string imageUrl2 = SaveFile(Image2, adFolder);
                    string imageUrl3 = SaveFile(Image3, adFolder);

                    command.Parameters.AddWithValue("@ImageUrl", (object)imageUrl1 ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ImageUrl2", (object)imageUrl2 ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ImageUrl3", (object)imageUrl3 ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }

                // بازگشت به صفحه جزئیات آگهی یا صفحه موفقیت
                Response.Redirect("Details.aspx?id=" + id);
            }
        }

        private string SaveFile(FileUpload fileUpload, string folderPath)
        {
            if (fileUpload.HasFile)
            {
                string fileName = Path.GetFileName(fileUpload.FileName);
                string filePath = Path.Combine(folderPath, fileName);
                fileUpload.SaveAs(filePath);
                return $"/Files/Uploads/{Path.GetFileName(folderPath)}/{fileName}";
            }
            return null;
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // بازگشت به صفحه جزئیات آگهی
            Response.Redirect("Details.aspx?id=" + Request.QueryString["id"]);
        }
    }
}
