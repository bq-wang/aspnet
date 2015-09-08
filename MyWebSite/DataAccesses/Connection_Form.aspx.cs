using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace MyWebSite.DataAccesses
{
    public partial class Connection_Form : System.Web.UI.Page
    {
        // this form is to test the connection on this box 
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["NorthWind"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();
                lblInfo.Text = "<b>Server version: </b>" + con.ServerVersion ;
                lblInfo.Text += "<br /><b>Connection is :</b> " + con.State.ToString();
            }
            catch (Exception ex)
            {
                // display information to show that error has happended
                lblInfo.Text = "error reading the database :" + ex.Message;
            }
            finally
            {
                con.Close();
                lblInfo.Text += "<br /><b> Now connection is :</b>" + con.State.ToString();
            }

        }
    }
}
