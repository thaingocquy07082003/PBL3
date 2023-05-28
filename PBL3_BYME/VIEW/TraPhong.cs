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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PBL3_BYME.VIEW
{
    public partial class TraPhong : Form
    {
        private string ID_HoaDon { get; set; }
        TraPhong_BLL traphong = new TraPhong_BLL();
        public TraPhong(string ID_HoaDon)
        {
            InitializeComponent();
            this.ID_HoaDon = ID_HoaDon;
            GUI();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        public void GUI()
        {
            label17.Text = ID_HoaDon;
            HoaDon hoadon = traphong.GetHoaDonByIdHoaDon(ID_HoaDon);
            label18.Text = hoadon.IdKhachHang;
            label19.Text = traphong.GetNameKhachHang(hoadon.IdKhachHang);
            label20.Text = traphong.GetNamePhong(traphong.GetIdPhong(traphong.GetIdBookByIdKH(hoadon.IdKhachHang,hoadon.IdNhanVien)));
            label21.Text = traphong.GetNameNV(hoadon.IdNhanVien);
            label22.Text = traphong.GetCheckInDay(traphong.GetIdBookByIdKH(hoadon.IdKhachHang, hoadon.IdNhanVien)).ToString();
            label23.Text = traphong.GetCheckOutDay(traphong.GetIdBookByIdKH(hoadon.IdKhachHang, hoadon.IdNhanVien)).ToString();
            ChiTietThuePhong chitietthuephong = traphong.Getchitiet(traphong.GetIdPhong(traphong.GetIdBookByIdKH(hoadon.IdKhachHang, hoadon.IdNhanVien)));
            DateTime startDate = traphong.GetCheckInDay(traphong.GetIdBookByIdKH(hoadon.IdKhachHang, hoadon.IdNhanVien)); // Ngày bắt đầu
            DateTime endDate = traphong.GetCheckOutDay(traphong.GetIdBookByIdKH(hoadon.IdKhachHang, hoadon.IdNhanVien)); // Ngày kết thúc

            TimeSpan duration = endDate - startDate; // Tính khoảng thời gian giữa hai ngày

            int numberOfDays = duration.Days; // Lấy số ngày
            label25.Text = (traphong.GetCostOfRoom(label20.Text) * numberOfDays).ToString();
            label26.Text = traphong.GetCostDV(traphong.GetIdPhong(traphong.GetIdBookByIdKH(hoadon.IdKhachHang, hoadon.IdNhanVien))).ToString();
            label27.Text = traphong.GetCostVD(hoadon.IdHoaDon).ToString();
            label28.Text = hoadon.TienTraTruoc.ToString();
            label29.Text = (Convert.ToInt32(label25.Text) + Convert.ToInt32(label26.Text) + Convert.ToInt32(label27.Text) - Convert.ToInt32(label28.Text)).ToString();
            dataGridView2.DataSource = traphong.GetAllChiTietDV(hoadon.IdHoaDon);
            dataGridView1.DataSource = traphong.GetAllLamHu(ID_HoaDon);
            comboBox1.Items.AddRange(traphong.GetAllNameVD().ToArray());
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];
            textBox3.Text = traphong.GetNameDVbyID(row.Cells["ID_DichVu"].Value.ToString());
            textBox5.Text = traphong.GetGiaDV(row.Cells["ID_DichVu"].Value.ToString()).ToString();
            textBox4.Text = row.Cells["SoLuong"].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(row.Cells["NgaySuDung"].Value);
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            int index = comboBox1.FindStringExact(row.Cells["VatDung"].Value.ToString());
            if (index != -1)
            {
                comboBox1.SelectedIndex = index;
            }
            textBox1.Text = row.Cells["DonGia"].Value.ToString();
            textBox2.Text = row.Cells["SoLuong"].Value.ToString();
        }
    }
}
