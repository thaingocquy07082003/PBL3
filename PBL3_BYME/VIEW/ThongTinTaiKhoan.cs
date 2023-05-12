using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using PBL3_BYME.BLL;
namespace PBL3_BYME.VIEW
{
    public partial class ThongTinTaiKhoan : Form
    {
        private string IdNV { get; set; }
        private QLKSEntities db = new QLKSEntities();
        private QL_NhanVien qlnv = new QL_NhanVien();
        public ThongTinTaiKhoan(string idnv)
        {
            InitializeComponent();
            IdNV = idnv;
        }


        public void Display()
        {
            foreach(NhanVien i in db.NhanViens.ToList())
            {
                if(i.IdNhanVien == IdNV)
                {
                    textBox1.Text = i.Ten;
                    textBox2.Text = qlnv.GetTenCV(i.IdChucVu);
                    textBox3.Text = i.CMND;
                    textBox4.Text = i.SDT;
                    textBox5.Text = i.DiaChi;


                }
            }
        }
    }
}
