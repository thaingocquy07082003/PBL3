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

namespace PBL3_BYME.VIEW
{
    public partial class FormQLPhong : Form
    {
        private QL_Phong qlp = new QL_Phong();
        public FormQLPhong()
        {
            InitializeComponent();
            Display();
        }
        public void Display()
        {
            dataGridView1.DataSource = qlp.getAllPhong();

            cbLoaiPhong.DataSource = qlp.getAllLoaiPhong();
            cbLoaiPhong.DisplayMember = "TenLoaiPhong";
            cbLoaiPhong.ValueMember = "IdLoaiPhong";
        }

        private void FormQLPhong_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            qlp.Them(cbLoaiPhong.SelectedValue.ToString(), txtIDPhong.Text, txtTen.Text, Convert.ToInt32(txtGia.Text), true);
            dataGridView1.DataSource = qlp.getAllPhong();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            object id = txtIDPhong.Text;
            object ten = txtTen.Text;
            object gia = txtGia.Text;
            object tt = txtTrangThai.Text;

            qlp.Update(id.ToString(), ten.ToString(), Convert.ToInt32(gia), bool.Parse(tt.ToString()));
            dataGridView1.DataSource = qlp.getAllPhong();
            MessageBox.Show("Sửa thành công");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        { 

            txtIDPhong.Text = dataGridView1.SelectedRows[0].Cells["IdPhong"].Value.ToString();
            txtTen.Text = dataGridView1.SelectedRows[0].Cells["TenPhong"].Value.ToString();
            txtGia.Text = dataGridView1.SelectedRows[0].Cells["DonGiaPhong"].Value.ToString();
            txtTrangThai.Text = dataGridView1.SelectedRows[0].Cells["TrangThai"].Value.ToString();
            dataGridView2.DataSource = qlp.GetVatDungPhongByID(dataGridView1.SelectedRows[0].Cells["IdPhong"].Value.ToString());
        }
    }
}
