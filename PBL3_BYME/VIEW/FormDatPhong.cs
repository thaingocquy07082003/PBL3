﻿using System;
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
    public partial class FormDatPhong : Form 
    {
        private DatPhong_BLL datphong = new DatPhong_BLL();
        private QL_KhachHang qlkh = new QL_KhachHang();
        List<ChiTietBook> listchitiet = new List<ChiTietBook>();
        public FormDatPhong()
        {
            InitializeComponent();
            SetLoadForm();
        }
        // Setup cho Thong tin dat phong
        public void SetLoadForm()
        {
            label4.Text = datphong.getNewIDBook();
            
            label6.Text = datphong.getIDNhanVien();
            textBox1.Enabled = false;
            List<PHONG> list = datphong.GetAllPhong();
            foreach(PHONG i in list)
            {
                comboBox1.Items.Add(i.TenPhong);
            }
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == null || dateTimePicker1.Value.CompareTo(dateTimePicker2.Value) == 0)
            {
                MessageBox.Show("Không hợp lệ !");
            }
            if (dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng !");
            }
            string IdBook = label4.Text;
            if(datphong.CheckIDBook(IdBook) == true)
            {
                IdBook = datphong.GetIdBookByIdKH(label5.Text);
            }
            ChiTietBook a = new ChiTietBook
            {
                IdChiTietBook = datphong.GetNewIDCTB(),
                IdPhong = datphong.GetIDPhongByTenPhong(comboBox1.SelectedItem.ToString()),
                IdBook = IdBook,
                NgayCheckInPhong = dateTimePicker1.Value.Date,
                NgayCheckOutPhong = dateTimePicker2.Value.Date,
                TrangThai = false,
            };
            listchitiet.Add(a);
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = listchitiet;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormChonKhachHang chon = new FormChonKhachHang();
            chon.d = new FormChonKhachHang.Mydel(SetDGV1);
            chon.ShowDialog();
            chon = null;
            this.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
            }
        }

        // Hien Thi Tren DGV thong tin khach hang vua chon 
        public void SetDGV1(string MaKH)
        {
            dataGridView1.DataSource = qlkh.getKhachHangByMaKH(MaKH);         
            label5.Text = MaKH;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
