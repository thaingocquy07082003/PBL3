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
    public partial class FormQLHoaDon : Form
    {
        private QL_HoaDon qlhd = new QL_HoaDon();
        private QL_KhachHang qlkh = new QL_KhachHang();
        public FormQLHoaDon()
        {
            InitializeComponent();
            Display();
        }
        private void Display ()
        {
            dataGridView1.DataSource = qlhd.getAllHoaDon();

            cbKH.DataSource = qlhd.getAllKhachHang();
            cbKH.DisplayMember = "Ten";
            cbKH.ValueMember = "IdKhachHang";

            cbNV.DataSource = qlhd.getAllNhanVien();
            cbNV.DisplayMember = "Ten";
            cbNV.ValueMember = "IdNhanVien";

            cbPhong.DataSource = qlhd.getAllPhong();
            cbPhong.DisplayMember = "TenPhong";
            cbPhong.ValueMember = "IdPhong";

            cbVD.DataSource = qlhd.getAllLoaiVatDung();
            cbVD.DisplayMember = "TenVatDung";
            cbVD.ValueMember = "IdLoaiVatDung";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            object IdHoaDon = txtIDHoaDon.Text;
            object IdKhachHang = cbKH.SelectedValue.ToString();
            object IdNhanVien = cbNV.SelectedValue.ToString();
            object NgayHoaDon = dtpNgayHoaDon.Value;
            object TinhTrang = txtTinhTrang.Text;
            object GhiChu = txtGhiChu.Text;
            object TienTraTruoc = txtTienTraTrc2.Text;

            qlhd.Update(IdHoaDon.ToString(), IdKhachHang.ToString(), IdNhanVien.ToString(), DateTime.Parse(NgayHoaDon.ToString()), bool.Parse(TinhTrang.ToString()), GhiChu.ToString(), Convert.ToDecimal(TienTraTruoc.ToString()));
            dataGridView1.DataSource = qlhd.getAllHoaDon();
            MessageBox.Show("Sửa thành công");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        //private void btnXoa_Click(object sender, EventArgs e)
        //{
        //    if (dataGridView1.SelectedRows.Count > 0)
        //    {
        //        qlhd.delete(txtIDHoaDon.Text);
        //        dataGridView1.DataSource = qlhd.getAllHoaDon();
        //        MessageBox.Show("Removed");
        //    }
        //}

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            object IdHoaDon = txtIDHoaDon.Text;
            object IdKhachHang = cbKH.SelectedValue.ToString();
            object IdNhanVien = cbNV.SelectedValue.ToString();
            object NgayHoaDon = dtpNgayHoaDon.Value;
            object TinhTrang = txtTinhTrang.Text;
            object GhiChu = txtGhiChu.Text;
            object TienTraTruoc = txtTienTraTrc2.Text;
            object IdPhong = cbPhong.SelectedValue.ToString();
            object IdVatDung = cbVD.SelectedValue.ToString();
            object Soluong = txtSoLuong.Text;

            qlhd.ThemHoaDon(IdPhong.ToString(),IdVatDung.ToString(),Convert.ToInt32(Soluong),IdHoaDon.ToString(),IdKhachHang.ToString(),IdNhanVien.ToString(),Convert.ToDateTime(NgayHoaDon),Convert.ToBoolean(TinhTrang),GhiChu.ToString(),Convert.ToDecimal(TienTraTruoc));
            Display();
            //qlhd.ThemHoaDon(qlhd.GetIDPhong(cbPhong.SelectedValue.ToString()),cbVD.SelectedValue.ToString(), Convert.ToInt32(txtSoLuong.Text), txtIDHoaDon.Text, qlhd.GetIDKhachHang(cbKH.SelectedItem.ToString()), qlhd.GetIDNhanVien(cbNV.SelectedItem.ToString()), Convert.ToDateTime(dtpNgayHoaDon.Value), true, txtGhiChu.Text, Convert.ToDecimal(txtTienTraTrc2.Text));
            //dataGridView1.DataSource = qlhd.getAllHoaDon();
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
                table.Columns.Add("IdHoaDon");
                table.Columns.Add("IdKhachHang");
                table.Columns.Add("IdNhanVien");
                table.Columns.Add("NgayHoaDon");
                table.Columns.Add("TinhTrang");
                table.Columns.Add("GhiChu");
                table.Columns.Add("TienTraTruoc");

                // ...

                // Populate the DataTable object with data from the selected row of the DataGridView1 control
                DataRow row = table.NewRow();
                row["IdHoaDon"] = selectedRow.Cells["IdHoaDon"].Value;
                row["IdKhachHang"] = selectedRow.Cells["IdKhachHang"].Value;
                row["IdNhanVien"] = selectedRow.Cells["IdNhanVien"].Value;
                row["NgayHoaDon"] = selectedRow.Cells["NgayHoaDon"].Value;
                row["TinhTrang"] = selectedRow.Cells["TinhTrang"].Value;
                row["GhiChu"] = selectedRow.Cells["GhiChu"].Value;
                row["TienTraTruoc"] = selectedRow.Cells["TienTraTruoc"].Value;
                // ...
                table.Rows.Add(row);

                txtTinhTrang.Text = selectedRow.Cells["TinhTrang"].Value.ToString();
                txtTienTraTrc2.Text = selectedRow.Cells["TienTraTruoc"].Value.ToString();
                txtGhiChu.Text = selectedRow.Cells["GhiChu"].Value.ToString();
                txtIDHoaDon.Text = selectedRow.Cells["IdHoaDon"].Value.ToString();


                // Set the DataTable object as the DataSource of the DataGridView2 control to display the selected row data in DataGridView2
                dataGridView2.DataSource = table;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                qlhd.delete(txtIDHoaDon.Text);
                dataGridView1.DataSource = qlhd.getAllHoaDon();
                MessageBox.Show("Removed");
            }
        }

        //private void btnXoa_Click_1(object sender, EventArgs e)
        //{
        //    if (dataGridView1.SelectedRows.Count > 0)
        //    {
        //        qlhd.delete(txtIDHoaDon.Text);
        //        dataGridView1.DataSource = qlhd.getAllHoaDon();
        //        MessageBox.Show("Removed");
        //    }
        //}
    }
}
