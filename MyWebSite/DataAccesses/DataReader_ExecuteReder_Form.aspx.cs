using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Configuration;

namespace MyWebSite.DataAccesses
{
    public partial class DataReader_ExecuteReader_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var connectionString = WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;
            
            SqlConnection con = new SqlConnection(connectionString);
            string sql = "SELECT * FROM Employees";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = null;

            try
            {
                con.Open();
                //reader = cmd.ExecuteReader();
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                // build the output 

                StringBuilder htmlStr = new StringBuilder("");
                while (reader.Read())
                {
                    htmlStr.Append("<li>");
                    htmlStr.Append(reader["TitleOfCourtesy"]);
                    htmlStr.Append("<b>");
                    htmlStr.Append(reader.GetString(1));
                    htmlStr.Append("</b>, ");
                    htmlStr.Append(reader.GetString(2));
                    htmlStr.Append(" - employee from ");
                    htmlStr.Append(reader.GetDateTime(6).ToString("d"));
                    htmlStr.Append("</li>");
                }

                HtmlContent.Text = htmlStr.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (con != null)
                    con.Close();
            }
        }
    }
}
