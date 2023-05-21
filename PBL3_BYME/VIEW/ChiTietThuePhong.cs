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
    public partial class ChiTietThuePhong : Form
    {
        private int Id_CTSuDungDV { get; set; }
        private string ID_Phong { get; set; }
        private string ID_DichVu { get; set; }
        private string ID_HoaDon { get; set; }
        QLKSEntities db = new QLKSEntities();
        BLL_ChiTietDichVu ctdv = new BLL_ChiTietDichVu();
        public ChiTietThuePhong()
        {
            InitializeComponent();
            Display();
        }
        public ChiTietThuePhong(string id, string idphong)
        {
            InitializeComponent();
            ID_HoaDon = id;
            ID_Phong = idphong;
            Display();
            SetUp();
        }

        public void SetUp()
        {
            textBox4.Text = ID_HoaDon;
            textBox4.Enabled = false;
            textBox3.Text = ctdv.GetNameKhachHang(ctdv.GetIDKhachHang(ID_HoaDon));
            textBox3.Enabled = false;
            textBox2.Text = ctdv.GetNamePhong(ID_Phong);
            textBox2.Enabled = false;
        }
        public void Display()
        {
            dataGridView1.DataSource = ctdv.GetAllDichVu();
            dataGridView2.DataSource = ctdv.GetAllChiTietDV();
        }
    }
}
