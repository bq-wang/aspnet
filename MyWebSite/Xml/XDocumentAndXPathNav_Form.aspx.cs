using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.XPath;

namespace MyWebSite.Xml
{
    public partial class XDocumentAndXPathNav_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //ReadXML();

              // now switch to the XNavDescr way 
              ReadXMLNav();
            }

        }


        private void ReadXML()
        {
            string xmlFile = Server.MapPath("DvdList.xml");
            XmlDocument document = new XmlDocument();
            document.Load(xmlFile);
            lblXml.Text = GetChildNodesDescr(document.ChildNodes, 0);
        }
        
        private void ReadXMLNav()
        {
          string xmlFile = Server.MapPath("DvdList.xml");
          XmlDocument document = new XmlDocument();
          document.Load(xmlFile);

          // create the navigator
          XPathNavigator xnav = document.CreateNavigator();
          lblXml.Text = GetXNavDescr(xnav, 0);
        }

        /// <summary>
        /// Get XNav Description - Navigator is a more streamlined, more lightweighted way to load xml in memory and visit
        /// </summary>
        /// <param name="xnav"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        private string GetXNavDescr(XPathNavigator xnav, int level)
        {

          string indent = "";
          for (int i = 0; i < level; i++)
          {
            indent += "&nbsp;&nbsp;&nbsp;";
          }

          StringBuilder str = new StringBuilder();

          switch (xnav.NodeType)
          {
            case XPathNodeType.Root:
              str.Append("<b>ROOT</b>");
              str.Append("<br />");
              break;
            case XPathNodeType.Element:
              ; str.Append(indent);
              str.Append(" - Value: <b>");
              str.Append(xnav.Name);
              str.Append("<b><br />");
              break;
            case XPathNodeType.Text:
              str.Append(indent);
              str.Append("Element: <b>");
              str.Append(xnav.Value);
              str.Append("<b><br />");
              break;
            case XPathNodeType.Comment:
              str.Append(indent);
              str.Append("Comment: <b>");
              str.Append(xnav.Value);
              str.Append("<b><br />");
              break;
          }

          if (xnav.HasAttributes)
          {
            xnav.MoveToFirstAttribute();
            do
            {
              str.Append(indent);
              str.Append(" - Attribute: <b>");
              str.Append(xnav.Name);
              str.Append("</b> Value: <b>");
              str.Append(xnav.Value);
              str.Append("</b><br />");
            } while (xnav.MoveToNextAttribute());
            // once it has done visiting the Attributes, return back to the parent

            xnav.MoveToParent();
          }

          if (xnav.HasChildren)
          {
            xnav.MoveToFirstChild();
            do
            {
              str.Append(GetXNavDescr(xnav, level + 1));
            } while (xnav.MoveToNext());

            xnav.MoveToParent();
          }

          return str.ToString();
        }

        private string GetChildNodesDescr(XmlNodeList nodeList,  int level)
        {
            string indent = "";
            for (int i = 0; i < level; i++)
            {
                indent += "&nbsp;&nbsp;&nbsp;";
            }

            StringBuilder str = new StringBuilder();

            foreach (XmlNode node in nodeList)
            {
                switch (node.NodeType)
                {
                    case XmlNodeType.XmlDeclaration:
                        str.Append("XML Declaration: <b>");
                        str.Append(node.Name);
                        str.Append(" ");
                        str.Append(node.Value);
                        str.Append("</b><br />");
                        break;
                    case XmlNodeType.Element:
                        str.Append(indent);
                        str.Append("Element: <b>");
                        str.Append(node.Name);
                        str.Append("</b><br />");
                        break;
                    case XmlNodeType.Text:
                        str.Append(indent);
                        str.Append("- Value : <b>");
                        str.Append(node.Value);
                        str.Append("</b><br />");
                        break;
                    case XmlNodeType.Comment:
                        str.Append(indent);
                        str.Append("Commment: <b>");
                        str.Append(node.Value);
                        str.Append("</b><br />");
                        break;
                }

                if (node.Attributes != null)
                {
                    foreach (XmlAttribute attrib in node.Attributes)
                    {
                        str.Append(indent);
                        str.Append(" - Attribute: <b>");
                        str.Append(attrib.Name);
                        str.Append("</b> Value: <b>");
                        str.Append(attrib.Value);
                        str.Append("</b><br />");
                    }
                }

                if (node.HasChildNodes) 
                {
                    str.Append(GetChildNodesDescr(node.ChildNodes, level+1));
                }
            }

            return str.ToString();
        }
    }
}