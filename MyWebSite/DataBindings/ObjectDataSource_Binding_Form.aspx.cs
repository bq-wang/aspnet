using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebSite.DataBindings
{
  public partial class ObjectDataSource_Binding_Form : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {

        DropDownListCities.DataSource = sourceEmployeeCities.Select(DataSourceSelectArguments.Empty);
        DropDownListCities.DataBind();

        // add two items adn select one 
        DropDownListCities.Items.Insert(0, "(Choose a City)");
        DropDownListCities.Items.Insert(1, "(All Cities)");
        DropDownListCities.SelectedIndex = 0;
      }
    }

    protected void sourceEmployee_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
      if (e.InputParameters["EmployeeID"] == null) e.Cancel = true;
    }

    protected void sourceEmployees_updating_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
      //e.InputParameters["id"] = e.InputParameters["EmployeeID"];
      e.InputParameters["employeeID"] = e.InputParameters["EmployeeID"];
      e.InputParameters.Remove("EmployeeID");
    }

    protected void userAddedOptions_sourceEmployees_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
      if ((string)e.Command.Parameters["@City"].Value == "(Choose a City)")
      {
        // don't do any thing 
        e.Cancel = true;
      }
      else if ((string)e.Command.Parameters["@City"].Value == "(All Cities)")
      {
        e.Command.CommandText = "SELECT * FROM Employees";
      }
    }
  }
}