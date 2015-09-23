﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace MyWebSite.Xml
{
    public partial class XDocumentAndXPathNav_Form : System.Web.UI.Page
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
            XmlDocument document = new XmlDocument();
            document.Load(xmlFile);
            lblXml.Text =  GetChildNodesDescr(document.ChildNodes, 0);
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