using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Configuration;

namespace MyWebSite.DataSets
{
    public partial class DataAdapterFillDataSet_Form : System.Web.UI.Page
    {
        // this form will show you how the DataAdapter to Fill DataSet
        protected void Page_Load(object sender, EventArgs e)
        {
            WriteEmployeeList();
        }

        public void WriteEmployeeList()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            string sql = "SELECT * FROM Employees";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            DataSet ds = new DataSet();
            da.Fill(ds, "Employees");

            StringBuilder htmlStr = new StringBuilder();
                foreach (DataRow dr in ds.Tables["Employees"].Rows)
                {
                    htmlStr.Append("<li>");
                    htmlStr.Append(dr["EmployeeID"]);
                    htmlStr.Append(" ");
                    htmlStr.Append(dr["TitleOfCourtesy"]);

                    htmlStr.Append(" <b>");
                    htmlStr.Append(dr["LastName"]);

                    htmlStr.Append(" </b>, ");
                    htmlStr.Append(dr["LastName"]);

                    htmlStr.Append("</li>");
                }

            HtmlContent.Text = htmlStr.ToString();
        } 
    }
}
