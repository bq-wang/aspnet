using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.DataSets
{
    public partial class DataView_Filter_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string connectionString = WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            // Data
            string sql = "SELECT ProductID, ProductName, UnitsInStock, UnitsOnOrder," + "Discontinued FROM Products";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();

            da.Fill(ds, "Products");

            
            // Origin view
            filter1.Text = "<b>" + "Filter = " + "ProductName = 'Chocolade'" + "</b>";
            DataView view1 = new DataView(ds.Tables["Products"]);
            view1.RowFilter = "ProductName = 'Chocolade'";
            grid1.DataSource = view1;

            // sorting 1
            filter2.Text = "<b>" + "Filter = " + "UnitsInStock = 0 AND UnitsOnOrder = 0" + "</b>";
            DataView view2 = new DataView(ds.Tables["Products"]);
            view2.RowFilter = "UnitsInStock = 0 AND UnitsOnOrder = 0";
            grid2.DataSource = view2;

            // Sorting 2
            filter3.Text = "<b>" + "Filter = " + "ProductName LIKE 'p%'" + "</b>";
            DataView view3 = new DataView(ds.Tables["Products"]);
            view3.RowFilter = "ProductName LIKE 'p%'";
            grid3.DataSource = view3;

            // it is possible to sort by two fields ,e.g. View2.Sort = "FirstName, LastName";
            // Last but not the least, --- Page.DataBind()
            Page.DataBind();
        }
    }
}
