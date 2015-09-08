using System;
using System.Data.SqlClient;
using System.Text;
using System.Web.Configuration;

namespace MyWebSite.DataSets
{
    public partial class StrongTyped_DataSet_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            // Data
            string sqlProducts = "SELECT * FROM Products";
            string sqlCategories = "SELECT * FROM Categories";

            NorthwindDataSet ds = new NorthwindDataSet();

            // TO Fill the dataset

            SqlDataAdapter da = new SqlDataAdapter(sqlCategories, con);
            da.Fill(ds.Categories);

            da.SelectCommand.CommandText = sqlProducts;
            da.Fill(ds.Products);

            // to construct HTML string
            StringBuilder htmlStr = new StringBuilder("");
            foreach (NorthwindDataSet.CategoriesRow row in ds.Categories)
            {
                htmlStr.Append("<b>");
                htmlStr.Append(row.CategoryName);
                htmlStr.Append("</b><br /><i>");
                htmlStr.Append(row.Description);
                htmlStr.Append("</i><br />");

                // Get related product info
                // it uses the auxiliary methods GetChildRows()

                NorthwindDataSet.ProductsRow[] products = row.GetProductsRows();
                foreach (NorthwindDataSet.ProductsRow child in products)
                {
                    htmlStr.Append("<li>");
                    htmlStr.Append(child.ProductName);
                    htmlStr.Append("</li>");
                }

                htmlStr.Append("<br /><br />");
            }

            HtmlContent.Text = htmlStr.ToString();

        }
    }
}
