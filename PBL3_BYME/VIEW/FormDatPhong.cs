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
using PBL3_BYME.DTO;
using PBL3_BYME.VIEW;

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

        public FormDatPhong(string namephong, DateTime dt1, DateTime dt2)
        {
            InitializeComponent();
            SetLoadForm();
            int index = comboBox1.FindStringExact(namephong);
            if (index != -1)
            {
                comboBox1.SelectedIndex = index;
            }
            dateTimePicker1.Value = dt1;
            dateTimePicker2.Value = dt2;
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
            
            //if(datphong.CheckIDBook(label5.Text) == true)
            //{
            //    IdBook = datphong.GetIdBookByIdKH(label5.Text);
            //}
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
            if (comboBox1.SelectedItem == null || dataGridView2.Rows.Count <= 0)
            {
                MessageBox.Show("Không hợp lệ");
                return;
            }
            int tiencoc = 0;
            if (textBox1.Text != "") tiencoc = Convert.ToInt32(textBox1.Text);
            //if (datphong.CheckIDBook(label5.Text) == false)// kh chưa có book trong hệ thống
            //{
            //    datphong.AddBook(label5.Text, label6.Text, tiencoc);
            //}
            datphong.AddBook(label5.Text, label6.Text, tiencoc);
            datphong.AddChiTiet(listchitiet);
            string newid = datphong.GetNewIDHD();
            HoaDon hoadon = new HoaDon {
                 IdHoaDon = newid,
                 IdKhachHang = label5.Text,
                 IdNhanVien = label6.Text,
                 NgayHoaDon = DateTime.Now,
                 TinhTrang = false,
                 GhiChu = "Not thing",
                 
            };
            if (textBox1.Text == "")
            {
                hoadon.TienTraTruoc = 0;
            }
            else
            {
                hoadon.TienTraTruoc = Convert.ToInt32(textBox1.Text);
            }
            datphong.ADDHD(hoadon, datphong.GetIDPhongByTenPhong(comboBox1.SelectedItem.ToString()));
            MessageBox.Show("Đặt Phòng Thành Công");
            ChiTietThuePhongAdd fom = new ChiTietThuePhongAdd(newid, datphong.GetIDPhongByTenPhong(comboBox1.SelectedItem.ToString()));
            fom.ShowDialog();
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            TimPhong tim = new TimPhong();
            tim.Show();
        }
    }
}
