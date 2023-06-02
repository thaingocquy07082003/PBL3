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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace PBL3_BYME.VIEW
{
    public partial class TraPhong : Form
    {
        QLKSEntities db = new QLKSEntities();
        private string ID_HoaDon { get; set; }
        TraPhong_BLL traphong = new TraPhong_BLL();
        public TraPhong(string ID_HoaDon)
        {
            InitializeComponent();
            this.ID_HoaDon = ID_HoaDon;
            GUI(traphong.GetAllLamHu(ID_HoaDon));
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
        public long GetCostDV()
        {
            long s = 0;
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                s += (long)(Convert.ToInt32(row.Cells["DonGia"].Value) * Convert.ToInt32(row.Cells["SoLuong"].Value));
            }
            return s;
        }
        public void GUI(List<LamHu_view> data)
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
            SetDGV(data);
            label27.Text = GetCostDV().ToString();
            label28.Text = hoadon.TienTraTruoc.ToString();
            label29.Text = (Convert.ToInt32(label25.Text) + Convert.ToInt32(label26.Text) + Convert.ToInt32(label27.Text) - Convert.ToInt32(label28.Text)).ToString();
            dataGridView2.DataSource = traphong.GetAllChiTietDV(hoadon.IdHoaDon);
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
        public void SetDGV(List<LamHu_view> data)
        {
            dataGridView1.DataSource = data;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDon hoadon = traphong.GetHoaDonByIdHoaDon(ID_HoaDon);
                List<LamHu_view> data = traphong.GetAllLamHu(ID_HoaDon);
                data.Add(new LamHu_view
                {
                    IdHoaDon = ID_HoaDon,
                    VatDung = comboBox1.SelectedItem.ToString(),
                    DonGia = traphong.GetGiaVD(comboBox1.SelectedItem.ToString()),
                    SoLuong = Convert.ToInt32(textBox2.Text)
                });
                GUI(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                HoaDon hoadon = traphong.GetHoaDonByIdHoaDon(ID_HoaDon);

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    List<LamHu_view> data = new List<LamHu_view>();
                    foreach(DataGridViewRow row in dataGridView1.Rows)
                    {
                        data.Add(((LamHu_view)row.DataBoundItem));
                    }

                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        data.Remove(((LamHu_view)row.DataBoundItem));
                    }
                    GUI(data);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            HoaDon hoadon = traphong.GetHoaDonByIdHoaDon(ID_HoaDon);
            ChiTietThuePhongAdd dform = new ChiTietThuePhongAdd(ID_HoaDon, traphong.GetIdPhong(traphong.GetIdBookByIdKH(hoadon.IdKhachHang, hoadon.IdNhanVien)));
            dform.ShowDialog();
            dform = null;
            dataGridView2.DataSource = traphong.GetAllChiTietDV(hoadon.IdHoaDon);
            label26.Text = traphong.GetCostDV(traphong.GetIdPhong(traphong.GetIdBookByIdKH(hoadon.IdKhachHang, hoadon.IdNhanVien))).ToString();
            label29.Text = (Convert.ToInt32(label25.Text) + Convert.ToInt32(label26.Text) + Convert.ToInt32(label27.Text) - Convert.ToInt32(label28.Text)).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HoaDon hoadon = traphong.GetHoaDonByIdHoaDon(ID_HoaDon);
            ChiTietThuePhong chitiet = new ChiTietThuePhong
            {
                IdChiTietThuePhong = traphong.ID_ChiTietThuePhong_Auto(),
                IdHoaDon = ID_HoaDon,
                IdPhong = traphong.GetIdPhong(traphong.GetIdBookByIdKH(hoadon.IdKhachHang, hoadon.IdNhanVien)),
                NgayCheckIn = traphong.GetCheckInDay(traphong.GetIdBookByIdKH(hoadon.IdKhachHang, hoadon.IdNhanVien)),
                NgayCheckOut = traphong.GetCheckOutDay(traphong.GetIdBookByIdKH(hoadon.IdKhachHang, hoadon.IdNhanVien)),
                TrangThai = true,
                DonGia = Convert.ToInt32(label25.Text) + Convert.ToInt32(label26.Text) + Convert.ToInt32(label27.Text) - Convert.ToInt32(label28.Text)
            };
            traphong.ADDChiTietThuePhong(chitiet);
            ChiTietThuePhong chiTietThuePhong = new ChiTietThuePhong();
            traphong.SetTTPhong(chitiet.IdPhong);
            traphong.SetTTChiTietDV(chitiet.IdPhong);
            foreach (var i in db.ChiTietThuePhongs.Select(p => p))
            {
                if (i.IdPhong == chitiet.IdPhong && i.HoaDon.TinhTrang == false)
                {
                    chiTietThuePhong = i;
                    break;
                }
            }
            traphong.SetTTHoaDon(ID_HoaDon);
            MessageBox.Show("Thanh Toan thanh cong");
            this.Close();
        }
    }
}
