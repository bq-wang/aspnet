using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MyWebSite.DataAccesses
{
    public partial class DataView_Form : System.Web.UI.Page
    {
        // DataView 
        // to allow you to do DataBinding 
        //
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdGridViewBindingClick(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            // Data
            string sql = "SELECT TOP 5 EmployeeID, TitleOfCourtesy, LastName, FirstName FROM Employees";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();

            da.Fill(ds, "Employees");

            // Origin view
            grid1.DataSource = ds.Tables["Employees"];

            // sorting 1
            DataView view2 = new DataView(ds.Tables["Employees"]);
            view2.Sort = "LastName";
            grid2.DataSource = view2;

            // Sorting 2
            DataView view3 = new DataView(ds.Tables["Employees"]);
            view3.Sort = "FirstName";
            grid3.DataSource = view3;

            // it is possible to sort by two fields ,e.g. View2.Sort = "FirstName, LastName";
            // Last but not the least, --- Page.DataBind()
            Page.DataBind();
        }
    }
}
