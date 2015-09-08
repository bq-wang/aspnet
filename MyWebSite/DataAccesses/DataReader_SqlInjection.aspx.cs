using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace MyWebSite.DataAccesses
{
    public partial class DataReader_SqlInjection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // SQL Injection 
        // where you can input something like 
        // ALFKI' or '1'='1
        protected void cmdGetRecordsClick(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            string sql = "SELECT Orders.CustomerID, Orders.OrderID, COUNT(UnitPrice) AS Items, " +
                "SUM(UnitPrice * Quantity) AS Total FROM Orders " + "INNER JOIN [Order Details] " +
                "ON Orders.OrderID = [Order Details].OrderID " +
                "WHERE Orders.CustomerID = '" + txtID.Text + "'" +
                "GROUP BY Orders.OrderID, Orders.CustomerID";

            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            reader.Close();
            con.Close();
        }
    }
}
