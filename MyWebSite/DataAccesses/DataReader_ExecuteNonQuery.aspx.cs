using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.DataAccesses
{
    public partial class DataReader_ExecuteNonQuery : System.Web.UI.Page
    {
        // In this example, we will check do with ExecuteNonQuery method 
        // since this code would delete records from the DataBase, so that the code below is actualy not executed to verify the result
        protected void Page_Load(object sender, EventArgs e)
        {
            var connectionString = WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;

            SqlConnection con = new SqlConnection(connectionString);
            string sql = "DELET FROM Employees WHERE EmployeeID = " + empID.ToString();
            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                con.Open();
                int numAff = cmd.ExecuteNonQuery();
                HtmlContent.Text += string.Format("<br /> Delete  <b>{0}</b> Records<br />", numAff);
            }
            catch (SqlException ex)
            {
                HtmlContent.Text += string.Format("<br /> Error:<{0}<br /><br />", ex.Message);

            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }
    }
}
