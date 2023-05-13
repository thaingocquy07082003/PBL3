using PBL3_BYME.BLL;
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
    public partial class FormHome : Form
    {
        private QL_Phong qlp = new QL_Phong();
        public FormHome()
        {
            InitializeComponent();
            SetColor();
            Display();
        }
        public void SetColor()
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            TimPhong tim = new TimPhong();
            tim.ShowDialog();
            tim = null;
            this.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormDatPhong f = new FormDatPhong();
            f.Show();
        }

        public void Display()
        {
            dataGridView1.DataSource = qlp.GetPhongView();
        }
    }
}
