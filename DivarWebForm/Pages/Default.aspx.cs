using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

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
                connection.Open();
                string query = "SELECT Id, Title, Content, Price, Category, ImageUrl FROM Advertisements";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                AdsRepeater.DataSource = dataTable;
                AdsRepeater.DataBind();
            }
        }
    }
}
