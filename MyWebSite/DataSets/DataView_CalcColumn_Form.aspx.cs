using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace MyWebSite.DataSets
{
    public partial class DataView_CalcColumn_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            // Data
            string sqlCat = "SELECT CategoryID, CategoryName FROM Categories";
            string sqlProd = "SELECT ProductName, CategoryID, UnitPrice FROM Products";

            SqlDataAdapter da = new SqlDataAdapter(sqlCat, con);
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                da.Fill(ds, "Categories");
                da.SelectCommand.CommandText = sqlProd;
                da.Fill(ds, "Products");
            }
            finally
            {
                con.Close();
            }

            // now define the relationship between categories and the products
            DataRelation relat = new DataRelation("CatProds", ds.Tables["Categories"].Columns["CategoryID"], ds.Tables["Products"].Columns["CategoryID"]);
            ds.Relations.Add(relat);

            // create the calc columns
            DataColumn count = new DataColumn("Products (#)", typeof(int), "COUNT(Child(CatProds).CategoryID)");
            DataColumn max = new DataColumn("Most Expensive Product", typeof(decimal), "MAX(Child(CatProds).UnitPrice)");
            DataColumn min = new DataColumn("Least Expensive Product", typeof(decimal), "MIN(Child(CatProds).UnitPrice)");

            // Add the generated columns
            ds.Tables["Categories"].Columns.Add(count);
            ds.Tables["Categories"].Columns.Add(max);
            ds.Tables["Categories"].Columns.Add(min);

            grid1.DataSource = ds.Tables["Categories"];
            grid1.DataBind(); //  or Page.DataBind if there is more than one Grid1 which requires DataBind
        }
    }
}
