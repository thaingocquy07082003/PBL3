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
namespace PBL3_BYME.VIEW
{
    public partial class FormLichSuDangNhap : Form
    {
        private QL_TaiKhoan qltk = new QL_TaiKhoan();
        public FormLichSuDangNhap()
        {
            InitializeComponent();
            ShowDGV();
        }
        public void ShowDGV()
        {
            dataGridView1.DataSource = qltk.getAllTaiKhoan();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.DataSource = qltk.getAllLichSuByIdNhanVien(dataGridView1.SelectedRows[0].Cells["IdNhanVien"].Value.ToString());
        }
    }
}
