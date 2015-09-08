using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebSite.DataSets
{
    public partial class DataComponent_Form : System.Web.UI.Page
    {
        // this page will show you how you can use the Data Compoenent that we have created 
        // to acccess and modify data.
        private EmployeeDB db = new EmployeeDB();

        protected void Page_Load(object sender, EventArgs e)
        {
            WriteEmployeeList();

           int empID = db.InsertEmployee(new EmployeeDetails(0, "Mr.", "Bellinaso", "Marco"));

           HtmlContent.Text += "<br /> Inserted 1 employee.<br />";
           WriteEmployeeList();

           db.DeleteEmployee(empID);
           HtmlContent.Text += "<br /> Deleted 1 employee.<br />";

           WriteEmployeeList();
        }

        public void WriteEmployeeList()
        {
            StringBuilder htmlStr = new StringBuilder();
            int numEmployees = db.CountEmployees();


            htmlStr.Append("<br />Total Employee: <b>");
            htmlStr.Append(numEmployees.ToString());
            htmlStr.Append("</b><br />");
            List<EmployeeDetails> employees = db.GetEmployees();
            foreach (EmployeeDetails emp in employees)
            {
                htmlStr.Append("<li>");
                htmlStr.Append(emp.EmployeeID);
                htmlStr.Append(" ");
                htmlStr.Append(emp.TitleOfCourtesy);

                htmlStr.Append(" <b>");
                htmlStr.Append(emp.LastName);

                htmlStr.Append(" </b>, ");
                htmlStr.Append(emp.LastName);

                htmlStr.Append("</li>");
            }

            HtmlContent.Text += htmlStr.ToString();
        }
    }
}
