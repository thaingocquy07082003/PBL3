using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3_BYME.BLL;
namespace PBL3_BYME
{
    public partial class FormDatPhong : Form
    {
        public FormDatPhong()
        {
            InitializeComponent();
        }
        // Hien thi tren datagirdview
        public void DisplayDGV(string id)
        {
            QL_KhachHang qlkh = new QL_KhachHang();
            dataGridView1.DataSource = qlkh.getKhachHangByMaKH(id);
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //FormAdd fa = new FormAdd();
            //fa.ShowDialog();
            //fa = null;
            //this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormChonKhachHang chon = new FormChonKhachHang();
            chon.d = new FormChonKhachHang.Mydel(DisplayDGV);
            chon.ShowDialog();
            chon = null;
            this.Show();
        }
    }
}
