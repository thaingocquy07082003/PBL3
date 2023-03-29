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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDatPhong datphong = new FormDatPhong();
            datphong.ShowDialog();
            datphong = null;
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            DanhSachKhachHang dskh = new DanhSachKhachHang();
            dskh.ShowDialog();
            dskh = null;
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            QLNguoiDung qlnd = new QLNguoiDung();
            qlnd.ShowDialog();
            qlnd = null;
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormHome fh = new FormHome();
            fh.ShowDialog();
            fh = null;
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormBaoCao bc = new FormBaoCao();
            bc.ShowDialog();
            bc = null;
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
