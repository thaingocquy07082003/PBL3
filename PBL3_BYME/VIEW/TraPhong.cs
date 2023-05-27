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
        }
    }
}
