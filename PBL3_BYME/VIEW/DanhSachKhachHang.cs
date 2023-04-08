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
    public partial class DanhSachKhachHang : Form
    {
        public DanhSachKhachHang()
        {
            InitializeComponent();
            showCBB();
            showKH();
        }
        private void showCBB()
        {
            comboBox1.Items.Add("Nam");
            comboBox1.Items.Add("Nữ");
            string[] item = new string[] { "Mã khách hàng", "Tên khách hàng", "Quốc tịch" };
            comboBox2.Items.AddRange(item);
            comboBox2.SelectedIndex = 0;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        }private void showKH()
        {
            QLKS_DB dB = new QLKS_DB();
            dataGridView1.DataSource = dB.KhachHangs.ToList();
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
             
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            showKH();
        }
    }
}
