using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls; // اضافه کردن فضای نام مناسب
using DivarWebForm.Models;

namespace DivarWebForm.Pages
{
    public partial class AddAdvertisement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // هر گونه تنظیم اولیه
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string title = Title.Text;
                string content = Content.Text;
                int price = int.Parse(Price.Text);
                CategoryType category = (CategoryType)Enum.Parse(typeof(CategoryType), Category.SelectedValue);

                // مسیر محلی برای ذخیره تصاویر
                string uploadPath = Server.MapPath("~/Files/Uploads/");
                string adFolder = Path.Combine(uploadPath, $"advertisement_{Guid.NewGuid()}");
                Directory.CreateDirectory(adFolder);

                string imageUrl1 = SaveFile(Image1, adFolder);
                string imageUrl2 = SaveFile(Image2, adFolder);
                string imageUrl3 = SaveFile(Image3, adFolder);

                // ذخیره اطلاعات در پایگاه داده
                SaveAdvertisement(title, content, price, category, imageUrl1, imageUrl2, imageUrl3);

                // هدایت به صفحه موفقیت یا صفحه اصلی
                Response.Redirect("Default.aspx");
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

        private void SaveAdvertisement(string title, string content, int price, CategoryType category, string imageUrl1, string imageUrl2, string imageUrl3)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DivarConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    INSERT INTO Advertisements (Title, Content, Price, Category, ImageUrl, ImageUrl2, ImageUrl3, CreatedDate)
                    VALUES (@Title, @Content, @Price, @Category, @ImageUrl, @ImageUrl2, @ImageUrl3, @CreatedDate)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Content", (object)content ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Category", (int)category);
                    command.Parameters.AddWithValue("@ImageUrl", (object)imageUrl1 ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ImageUrl2", (object)imageUrl2 ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ImageUrl3", (object)imageUrl3 ?? DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
