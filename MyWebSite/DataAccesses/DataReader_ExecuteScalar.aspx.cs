using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Web.Configuration;

namespace MyWebSite.DataAccesses
{
    public partial class DataReader_ExecuteScalar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var connectionString = WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;

            SqlConnection con = new SqlConnection(connectionString);
            string sql = "SELECT COUNT(*) FROM Employees";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = null;

            try
            {
                con.Open();
                // build the output 
                var numEmployees = (int)cmd.ExecuteScalar();

                HtmlContent.Text = "<br />Total employees: <b>"
                    + numEmployees + "</b><br />";
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
