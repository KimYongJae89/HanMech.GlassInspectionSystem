using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Device.PLC;
using GlassInspectionSystem.Class;
using HMechUtility;

namespace GlassInspectionSystem.Params
{
    public class PLCAddressSettings
    {
        private void SavePLCAddressProperty(XmlElement plcAddressElement)
        {
            string elementName = "PLCProperty";
            foreach (ePLCAddress address in Enum.GetValues(typeof(ePLCAddress)))
            {
                foreach (PLCAddressProperty property in Status.Instance().Plc.PlcReceivePacketList)
                {
                    if(address == property.AddressName)
                    {
                        XmlElement plcAddressPropertyElement = plcAddressElement.OwnerDocument.CreateElement("", elementName, "");
                        plcAddressElement.AppendChild(plcAddressPropertyElement);

                        XmlHelper.SetValue(plcAddressPropertyElement, "AddressName", property.AddressName.ToString());
                        XmlHelper.SetValue(plcAddressPropertyElement, "AddressNumber", property.AddressNumber.ToString());
                        XmlHelper.SetValue(plcAddressPropertyElement, "AddressDataLength", property.AddressDataLength.ToString());
                        XmlHelper.SetValue(plcAddressPropertyElement, "DataType", property.DataType.ToString());
                        XmlHelper.SetValue(plcAddressPropertyElement, "UseAddress", property.UseAddress.ToString());
                        continue;    
                    }
                }
            }
        }

        public void Save(bool isBackUp = false)
        {
            string savePath = Directory.GetCurrentDirectory() + @"\config";
            Utility.CreateDir(savePath);
            savePath += @"\PLCAddressSettings.cfg";

            if (isBackUp)
            {
                string backupPath = savePath + ".bak";

                if (File.Exists(backupPath))
                    File.Create(backupPath);
                File.Move(savePath, backupPath);
            }

            XmlDocument xmlDocument = new XmlDocument();
            XmlHelper.SaveDeclaration(xmlDocument);
            XmlElement plcAddressElement = xmlDocument.CreateElement("", "PLCAddressProperty", "");
            xmlDocument.AppendChild(plcAddressElement);

            SavePLCAddressProperty(plcAddressElement);
            xmlDocument.Save(savePath);
        }

        private void LoadPLCAddressProperty(XmlElement plcAddressElement)
        {
            Status.Instance().Plc.PlcReceivePacketList.Clear();

            foreach (ePLCAddress address in Enum.GetValues(typeof(ePLCAddress)))
            {
                for (int i = 0; i < plcAddressElement.ChildNodes.Count; i++)
                {
                    XmlNodeList nodeList = plcAddressElement.ChildNodes[i].ChildNodes;
                    string addressName = XmlHelper.GetValue(nodeList, "AddressName", "");

                    if(addressName == address.ToString())
                    {
                        PLCAddressProperty property = new PLCAddressProperty();

                        string addressNumber = XmlHelper.GetValue(nodeList, "AddressNumber", "0");
                        string addressDataLength = XmlHelper.GetValue(nodeList, "AddressDataLength", "1");
                        string useAddress = XmlHelper.GetValue(nodeList, "UseAddress", "false");
                        string dataType = XmlHelper.GetValue(nodeList, "DataType", ePlcDataType.DEC.ToString());

                        property.AddressName = (ePLCAddress)Enum.Parse(typeof(ePLCAddress), addressName);
                        property.AddressNumber = Convert.ToInt16(addressNumber);
                        property.AddressDataLength = Convert.ToInt16(addressDataLength);
                        property.UseAddress = Convert.ToBoolean(useAddress);
                        property.DataType = (ePlcDataType)Enum.Parse(typeof(ePlcDataType), dataType);

                        Status.Instance().Plc.PlcReceivePacketList.Add(property);
                    }
                }
            }
        }

        public void Load()
        {
            string loadPath = Directory.GetCurrentDirectory() + @"\config";
            Utility.CreateDir(loadPath);
            loadPath += @"\PLCAddressSettings.cfg";

            if (!File.Exists(loadPath))
            {
                foreach (ePLCAddress address in Enum.GetValues(typeof(ePLCAddress)))
                {
                    PLCAddressProperty property = new PLCAddressProperty();
                    property.AddressName = address;
                    Status.Instance().Plc.PlcReceivePacketList.Add(property);
                }
                Save();
            }
            else
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(loadPath);
                XmlElement plcAddressElement = xmlDocument.DocumentElement;

                LoadPLCAddressProperty(plcAddressElement);
            }
        }
    }
}
