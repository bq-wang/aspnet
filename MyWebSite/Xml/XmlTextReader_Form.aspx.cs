using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace MyWebSite.Xml
{
    public partial class XmlTextReader_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ReadXML();
            }

        }


        private void ReadXML()
        {
            string xmlFile = Server.MapPath("DvdList.xml");

            // create the reader 
            XmlTextReader reader = new XmlTextReader(xmlFile);
            StringBuilder str = new StringBuilder();
            
            // iterate through the nodes 
            while (reader.Read()) 
            {
                switch (reader.NodeType) 
                {
                    case XmlNodeType.XmlDeclaration:
                        str.Append("XML Declaration: <b>");
                        str.Append(reader.Name);
                        str.Append("  ");
                        str.Append(reader.Value);
                        str.Append("</b><br />");
                        break;
                    case XmlNodeType.Element:
                        str.Append("Element : <b>");
                        str.Append(reader.Name);
                        str.Append("</b><br />");
                        break;
                    case XmlNodeType.Text:
                        str.Append(" - Value: <b>");
                        str.Append(reader.Value);
                        str.Append("</b><br />");
                        break;

                }

                if (reader.HasAttributes)
                {
                    while (reader.MoveToNextAttribute()) 
                    {
                        str.Append("  - Attribute: <b>");
                        str.Append(reader.Name);
                        str.Append("<b> Value: <b>");
                        str.Append(reader.Value);
                        str.Append("</b><br />");
                    }
                }
            }
            reader.Close();
            lblXml.Text = str.ToString();
        }
    }
}