using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.LinqSql
{
    public partial class LinqDataSource_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // now we have added the Partial class to Linq generate class, 
        // let's try to handle that gracefully
        protected void detailsEmployee_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            if (e.Exception != null)
            {
                // Has to enable EnableUpdate in DetailsView, otherwise, it goes to linqException branch.
                LinqDataSourceValidationException linqException = e.Exception as LinqDataSourceValidationException;
                if (linqException == null)
                {
                    lblError.Text = "Data Error";
                }
                else
                {
                    // to display all the validation error 
                    lblError.Text = "";
                    foreach (Exception err in linqException.InnerExceptions.Values)
                        lblError.Text += err.Message + "<br />";
                }
                e.ExceptionHandled = true;
            }
            else
            {
                gridEmployees.DataBind();
            }
        }
    }
}