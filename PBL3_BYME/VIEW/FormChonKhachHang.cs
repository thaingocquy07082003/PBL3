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
using PBL3_BYME.DTO;
namespace PBL3_BYME
{
    public partial class FormChonKhachHang : Form
    {
        public delegate void Mydel(string IDkh);
        public Mydel d;
        QL_KhachHang qlkh = new QL_KhachHang();
        public FormChonKhachHang()
        {
            InitializeComponent();
            SetCBB();
            SetDisplay();
        }

        public void SetDisplay()
        {
            dataGridView1.DataSource = qlkh.getAllKhachHang();
        }
        public void SetCBB()
        {
            comboBox1.Items.Add("IDKhachHang");
            comboBox1.Items.Add("CCCD");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            d(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAdd fa = new FormAdd();
            fa.ShowDialog();
            fa = null;
            this.Show();
            SetDisplay();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            QL_KhachHang qlkh = new QL_KhachHang();
            string truyvan = textBox1.Text;
            if(comboBox1.SelectedItem.ToString() == "IDKhachHang")
            {
                dataGridView1.DataSource = qlkh.getKhachHangByMaKH(truyvan);
            }
            else
            {
                dataGridView1.DataSource = qlkh.getKhachHangByCCCD(truyvan);
            }
        }
        
    }
}
