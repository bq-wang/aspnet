using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace MyWebSite.DataSets
{
  public partial class MultipleTablesAndRelations_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void cmdMultipleTablesRelationsClick(object sender, EventArgs args)
    {
      string connectionString = WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;

      SqlConnection con = new SqlConnection(connectionString);

      string sqlCat = "SELECT CategoryID, CategoryName FROM Categories";
      string sqlProd = "SELECT ProductName, CategoryID FROM Products";

      SqlDataAdapter da = new SqlDataAdapter(sqlCat, con);

      DataSet ds = new DataSet();

      try
      {
        con.Open();

        // fill two data sets
        da.Fill(ds, "Categories");
        da.SelectCommand.CommandText = sqlProd;
        da.Fill(ds, "Products");

        DataRelation relat = new DataRelation("CatProds", ds.Tables["Categories"].Columns["CategoryID"], ds.Tables["Products"].Columns["CategoryID"]);
        ds.Relations.Add(relat);

        StringBuilder sb = new StringBuilder("");
        foreach (DataRow row in ds.Tables["Categories"].Rows)
        {
          sb.Append("<b>");
          sb.Append(row["CategoryName"].ToString());
          sb.Append("</b>");
          sb.Append("<ul>");


          // to get child records for the parent records
          DataRow[] childRows = row.GetChildRows(relat);
          foreach (DataRow childRow in childRows)
          {
            sb.Append("<li>");
            sb.Append(childRow["ProductName"].ToString());
            sb.Append("</li>");
          }

          sb.Append("</ul>");
        }

        HtmlContent.Text = sb.ToString();

      }
      finally
      {
        con.Close();
      }
    }


  }
}