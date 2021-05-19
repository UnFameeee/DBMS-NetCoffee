using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalDBMS
{
    public partial class MomayFrm : Form
    {
        public MomayFrm()
        {
            InitializeComponent();
        }
        Device device = new Device();
        private void MomayFrm_Load(object sender, EventArgs e)
        {
            comboBoxChonmay.DataSource = device.getAllDevicesNotInUse();
            comboBoxChonmay.DisplayMember = "deviceid";
            comboBoxChonmay.ValueMember = "deviceid";
            comboBoxChonmay.SelectedItem = null;
        }
    }
}
