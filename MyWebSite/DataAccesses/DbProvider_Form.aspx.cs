using System;
using System.Data.Common;
using System.Text;
using System.Web.Configuration;

namespace MyWebSite.DataAccesses
{
    public partial class DbProvider_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        // the DbProvider form shows you how to use the DbFactoris to create Connection and Queries
        protected void cmdDbFactoryClick(object sender, EventArgs e)
        {
            // AppSettings - factory: System.Data.SqlClient
            string factory = WebConfigurationManager.AppSettings["factory"];
            DbProviderFactory provider = DbProviderFactories.GetFactory(factory);


            // to create one connection with the factory 
            DbConnection con = provider.CreateConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;

            // Create command
            DbCommand cmd = provider.CreateCommand();
            cmd.CommandText = WebConfigurationManager.AppSettings["employeeQuery"];
            cmd.Connection = con;

            con.Open();
            DbDataReader reader = cmd.ExecuteReader();


            StringBuilder htmlStr = new StringBuilder();
            int i = 0;
            while (reader.Read())
            {
                htmlStr.Append("<li>");
                htmlStr.Append(reader["TitleOfCourtesy"]);
                htmlStr.Append("<b>");

                htmlStr.Append(reader.GetString(1));
                htmlStr.Append("</b>");

                htmlStr.Append("<b>");
                htmlStr.Append(reader.GetString(2));
                htmlStr.Append("</b>");

                htmlStr.Append(" -- employee from ");
                htmlStr.Append(reader.GetDateTime(6).ToString("d"));

                htmlStr.Append("</li>");
            }

            HtmlContent.Text = htmlStr.ToString();
            con.Close();

        }
    }
}
