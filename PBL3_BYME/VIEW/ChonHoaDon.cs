using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3_BYME.DTO;
using PBL3_BYME.BLL;
namespace PBL3_BYME.VIEW
{
    public partial class ChonHoaDon : Form
    {
        ChonHoaDon_BLL chd = new ChonHoaDon_BLL();
        public ChonHoaDon()
        {
            InitializeComponent();
            GUI();
        }

        public void GUI()
        {
            dataGridView1.DataSource = chd.GetAllHoaDon();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            string idhoadon = row.Cells["IdHoaDon"].Value.ToString();
            TraPhong traphong = new TraPhong(idhoadon);
            traphong.ShowDialog();           
        }
    }
}
