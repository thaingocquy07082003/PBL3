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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PBL3_BYME.VIEW
{
    public partial class ThongTinTaiKhoan : Form
    {
        private string IdNV { get; set; }
        private QLKSEntities db = new QLKSEntities();
        private QL_NhanVien qlnv = new QL_NhanVien();
        private QL_TaiKhoan qltk = new QL_TaiKhoan();
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
                    textBox6.Text = i.NgayVaoLam.ToString();
                    if(i.GioiTinh == true)
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien
            {
                IdNhanVien = IdNV,
                IdChucVu = qlnv.GetIdChuvu(textBox2.Text.ToString()),
                IdTaiKhoan = qltk.GetIdTaiKhoan(IdNV),
                Ten = textBox1.Text,
                CMND = textBox3.Text,
                SDT = textBox4.Text,
                DiaChi = textBox5.Text,
                NgayVaoLam = Convert.ToDateTime(textBox6.Text),
            };
            if(radioButton1.Checked == true)
            {
                nv.GioiTinh = true;
            }
            else if(radioButton2.Checked == true)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
