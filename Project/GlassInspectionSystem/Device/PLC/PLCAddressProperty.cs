using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.PLC
{
    public class PLCAddressProperty
    {
        private bool _useAddress = false;
        public bool UseAddress
        {
            get { return _useAddress; }
            set { _useAddress = value; }
        }

        private ePLCAddress _addressName = ePLCAddress.PC_HEARTBEAT;
        public ePLCAddress AddressName
        {
            get { return _addressName; }
            set { _addressName = value; }
        }

        private int _addressNumber = 0;
        public int AddressNumber
        {
            get { return _addressNumber; }
            set { _addressNumber = value; }
        }

        private int _addresDataLength = 0;
        public int AddressDataLength
        {
            get { return _addresDataLength; }
            set { _addresDataLength = value; }
        }

        private ePlcDataType _dataType = ePlcDataType.DEC;
        public ePlcDataType DataType
        {
            get { return _dataType; }
            set { _dataType = value; }
        }

        private string _value = "";
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }


        public PLCAddressProperty Copy()
        {
            PLCAddressProperty property = new PLCAddressProperty();
            property.UseAddress = this.UseAddress;
            property.AddressName = this.AddressName;
            property.AddressNumber = this.AddressNumber;
            property.AddressDataLength = this.AddressDataLength;
            property.DataType = this.DataType;

            return property;
        }
    }
}
