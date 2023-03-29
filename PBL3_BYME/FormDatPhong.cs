using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3_BYME
{
    public partial class FormDatPhong : Form
    {
        public FormDatPhong()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAdd fa = new FormAdd();
            fa.ShowDialog();
            fa = null;
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormChonKhachHang chon = new FormChonKhachHang();
            chon.ShowDialog();
            chon = null;
            this.Show();
        }
    }
}
