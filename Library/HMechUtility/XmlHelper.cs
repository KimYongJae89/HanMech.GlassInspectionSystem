using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace HMechUtility
{
    public class XmlHelper
    {
        //Xml 선언부 삽입
        public static void SaveDeclaration(XmlDocument xmlDocument)
        {
            XmlDeclaration xmlDeclaration;
            xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement xmlElementRoot = xmlDocument.DocumentElement;
            xmlDocument.InsertBefore(xmlDeclaration, xmlElementRoot);
        }

        public static void SetValue(XmlElement xmlElement, string keyName, string value)
        {
            XmlElement subElement = xmlElement.OwnerDocument.CreateElement("", keyName, "");
            xmlElement.AppendChild(subElement);

            subElement.InnerText = value;
        }

        public static string GetValue(XmlElement xmlElement, string keyName, string defaultValue)
        {
            XmlElement subElement = xmlElement[keyName];
            if (subElement == null)
                return defaultValue;

            return subElement.InnerText;
        }

        public static string GetValue(XmlNode xmlNode, string keyName, string defaultValue)
        {
            XmlElement subElement = xmlNode[keyName];
            if (subElement == null)
                return defaultValue;

            return subElement.InnerText;
        }

        public static string GetValue(XmlNodeList xmlNodeList, string keyName, string defaultValue)
        {
            for(int i = 0; i < xmlNodeList.Count; i++)
            {
                if (xmlNodeList[i].Name == keyName)
                    return xmlNodeList[i].InnerText;
            }
            return defaultValue;
        }
    }
}
