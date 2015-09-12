using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWebSite.LinqSql.AutoGen;

namespace MyWebSite.LinqSql
{
    public partial class AutoGenLinqDb_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AutoGenLinqNorthwindDB db = new AutoGenLinqNorthwindDB();
            StringBuilder sb = new StringBuilder();
            foreach (Customers customer in db.GetCustomers())
            {
                sb.Append(customer.CompanyName);
                sb.Append("<br />");

                foreach (Orders order in customer.Orders)
                {
                    sb.Append(order.OrderID.ToString());
                    sb.Append(" - ");
                    sb.Append(order.OrderDate.Value.ToString());
                    sb.Append("<br />");
                }

                sb.Append("<hr /><br />");
            }


            lblInfo.Text = sb.ToString();

        }
    }
}