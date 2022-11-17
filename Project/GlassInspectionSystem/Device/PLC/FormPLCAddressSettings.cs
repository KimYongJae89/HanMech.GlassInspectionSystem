using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Device.PLC
{
    public partial class FormPLCAddressSettings : Form
    {
        public Action ApplyPLCAddresSettingsDelegate;
        public Action<List<PLCAddressProperty>> CloseEventDelegate;

        private PLCAddressProperty _plcAddressProperty = new PLCAddressProperty();
        public List<PLCAddressProperty> PLCAddressPropertyList = new List<PLCAddressProperty>();

        public List<PLCAddressProperty> PCtoPLCList = new List<PLCAddressProperty>();
        public List<PLCAddressProperty> PLCtoPCList = new List<PLCAddressProperty>();
        
        public FormPLCAddressSettings()
        {
            InitializeComponent();
        }

        private void FormPLCAddressSettings_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Initialize()
        {
            InitializeUI();
            InitializeDataTable();
        }

        private void InitializeUI()
        {
            SeparateAddress();

            // PC To PLC
            //dgvPCtoPLC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dgvPCtoPLC.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvPCtoPLC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPCtoPLC.MultiSelect = false;
            ColumnDataType1.DataSource = Enum.GetNames(typeof(ePlcDataType));
            foreach (DataGridViewColumn column in dgvPCtoPLC.Columns)
                column.SortMode = DataGridViewColumnSortMode.Programmatic;


            // PLC To PC
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.MultiSelect = false;
            ColumnDataType2.DataSource = Enum.GetNames(typeof(ePlcDataType));
            foreach (DataGridViewColumn column in dataGridView1.Columns)
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
        }

        private void SeparateAddress()
        {
            foreach (PLCAddressProperty addressProperty in PLCAddressPropertyList)
            {
                string[] temp = addressProperty.AddressName.ToString().Split('_');

                if (temp[0] == "PC")
                    PCtoPLCList.Add(addressProperty);
                else
                    PLCtoPCList.Add(addressProperty);
            }
        }

        private void InitializeDataTable()
        {
            //SeparateAddress();
            dgvPCtoPLC.Rows.Add(PCtoPLCList.Count);
            dataGridView1.Rows.Add(PLCtoPCList.Count);

            if (dgvPCtoPLC.Rows.Count < 1 && dataGridView1.Rows.Count < 1)
                return;

            for (int i = 0; i < dgvPCtoPLC.Rows.Count; i++)
            {
                dgvPCtoPLC[0, i].Value = PCtoPLCList[i].UseAddress.ToString();
                dgvPCtoPLC[1, i].Value = PCtoPLCList[i].AddressName.ToString();
                dgvPCtoPLC[2, i].Value = PCtoPLCList[i].AddressNumber.ToString();
                dgvPCtoPLC[3, i].Value = PCtoPLCList[i].AddressDataLength.ToString();
                dgvPCtoPLC[4, i].Value = PCtoPLCList[i].DataType.ToString();
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1[0, i].Value = PLCtoPCList[i].UseAddress.ToString();
                dataGridView1[1, i].Value = PLCtoPCList[i].AddressName.ToString();
                dataGridView1[2, i].Value = PLCtoPCList[i].AddressNumber.ToString();
                dataGridView1[3, i].Value = PLCtoPCList[i].AddressDataLength.ToString();
                dataGridView1[4, i].Value = PLCtoPCList[i].DataType.ToString();
            }
        }

        private void FormPLCAddressSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CloseEventDelegate != null)
                CloseEventDelegate(this.PLCAddressPropertyList);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            ApplySettings();
            MessageBox.Show("Apply Completed");
            this.Close();
        }

        private List<PLCAddressProperty> GetPLCAddressPropertyList()
        {
            foreach (DataGridViewRow dr in dgvPCtoPLC.Rows)
            {
                PLCAddressProperty property = new PLCAddressProperty();

                property.UseAddress = Convert.ToBoolean(dr.Cells[0].Value);
                property.AddressName = (ePLCAddress)Enum.Parse(typeof(ePLCAddress), dr.Cells[1].Value as string);
                property.AddressNumber = Convert.ToInt16(dr.Cells[2].Value);
                property.AddressDataLength = Convert.ToInt16(dr.Cells[3].Value);
                property.DataType = (ePlcDataType)Enum.Parse(typeof(ePlcDataType), dr.Cells[4].Value as string);

                PLCAddressPropertyList.Add(property);
            }

            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                PLCAddressProperty property = new PLCAddressProperty();

                property.UseAddress = Convert.ToBoolean(dr.Cells[0].Value);
                property.AddressName = (ePLCAddress)Enum.Parse(typeof(ePLCAddress), dr.Cells[1].Value as string);
                property.AddressNumber = Convert.ToInt16(dr.Cells[2].Value);
                property.AddressDataLength = Convert.ToInt16(dr.Cells[3].Value);
                property.DataType = (ePlcDataType)Enum.Parse(typeof(ePlcDataType), dr.Cells[4].Value as string);

                PLCAddressPropertyList.Add(property);
            }

            return PLCAddressPropertyList;
        }

        private void ApplySettings()
        {
            PLCAddressPropertyList.Clear();
            if (GetPLCAddressPropertyList() == null)
                return;

            if (ApplyPLCAddresSettingsDelegate != null)
                ApplyPLCAddresSettingsDelegate();
        }

        public void SetPLCPropertyList(List<PLCAddressProperty> propertyList)
        {
            PLCAddressPropertyList.Clear();
            PLCAddressPropertyList = propertyList.ToArray().ToList();
        }

//         private void SetPLCAddressProperty(PLCAddressProperty plcAddressProperty)
//         {
//             _plcAddressProperty.AddressName = plcAddressProperty.AddressName;
//             _plcAddressProperty.AddressNumber = plcAddressProperty.AddressNumber;
//             _plcAddressProperty.AddressDataLength = plcAddressProperty.AddressDataLength;
//             _plcAddressProperty.WordType = plcAddressProperty.WordType;
//             _plcAddressProperty.UseAddress = plcAddressProperty.UseAddress;
//         }
    }
}
