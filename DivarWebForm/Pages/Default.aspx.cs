using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace DivarWebForm.Pages
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAdvertisements();
            }
        }

        private void LoadAdvertisements()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DivarConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT a.Id, a.Title, a.Price, a.ImageUrl, c.Name AS CategoryName FROM Advertisements a JOIN CategoryTypes c ON a.Category = c.Id";

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

                foreach (DataRow row in dataTable.Rows)
                {
                    row["CategoryName"] = HttpUtility.HtmlDecode(row["CategoryName"].ToString());
                }

                AdsRepeater.DataSource = dataTable;
                AdsRepeater.DataBind();
            }
        }
    }
}
