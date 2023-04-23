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
    public partial class QLNguoiDung : Form
    {
        private QL_NhanVien qlnv = new QL_NhanVien();
        public QLNguoiDung()
        {
            InitializeComponent();
            Display();
        }

        public void Display()
        {
            dataGridView1.DataSource = qlnv.GetAllNhanVien();
            comboBox1.Items.Add("Nam");
            comboBox1.Items.Add("Nu");
            // setup cho cbb2
            comboBox2.Items.AddRange(qlnv.GetAllChucVu().ToArray());
            // setup cho cbb3 
            comboBox3.Items.Add("Ten");
            comboBox3.Items.Add("Ma Nhan Vien");
        }
        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Mode = comboBox3.SelectedIndex.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox9.Text = "";
            Display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox8.Text;
            dataGridView1.DataSource = qlnv.GetNVByName(name);
        }
    }
}
