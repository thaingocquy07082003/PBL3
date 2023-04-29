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
            dataGridView1.DataSource = qlnv.Sort(Mode);
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach(DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    qlnv.delete(i.Cells["IdNhanVien"].Value.ToString());
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            textBox1.Text = row.Cells["IdNhanVien"].Value.ToString();
            textBox2.Text = row.Cells["Ten"].Value.ToString();
            textBox3.Text= row.Cells["CMND"].Value.ToString();
            textBox4.Text = row.Cells["SDT"].Value.ToString();
            if (Convert.ToBoolean(row.Cells["GioiTinh"].Value) == true)
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.SelectedIndex = 1;
            }
            textBox5.Text = row.Cells["DiaChi"].Value.ToString();

        }
    }
}
