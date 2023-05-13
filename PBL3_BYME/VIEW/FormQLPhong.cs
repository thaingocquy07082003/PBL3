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
        public void Display ()
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row from DataGridView1
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Create a new DataTable to hold the selected row data
                DataTable table = new DataTable();

                // Add columns to the DataTable object to match the columns in the DataGridView2 control
                table.Columns.Add("IdPhong");
                table.Columns.Add("TenPhong");
                table.Columns.Add("DonGiaPhong");
                table.Columns.Add("TrangThai");

                // ...

                // Populate the DataTable object with data from the selected row of the DataGridView1 control
                DataRow row = table.NewRow();
                row["IdPhong"] = selectedRow.Cells["IdPhong"].Value;
                row["TenPhong"] = selectedRow.Cells["TenPhong"].Value;
                row["DonGiaPhong"] = selectedRow.Cells["DonGiaPhong"].Value;
                row["TrangThai"] = selectedRow.Cells["TrangThai"].Value;
                // ...
                table.Rows.Add(row);

                txtIDPhong.Text = selectedRow.Cells["IdPhong"].Value.ToString();
                txtTen.Text = selectedRow.Cells["TenPhong"].Value.ToString();
                txtGia.Text = selectedRow.Cells["DonGiaPhong"].Value.ToString();
                txtTrangThai.Text = selectedRow.Cells["TrangThai"].Value.ToString();

                // Set the DataTable object as the DataSource of the DataGridView2 control to display the selected row data in DataGridView2
                dataGridView2.DataSource = table;
                    }
        }
    }
}
