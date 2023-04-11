using PBL3_BYME.DTO;
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
using PBL3_BYME.VIEW;

namespace PBL3_BYME
{
    public partial class Main : Form
    {
        private string IDNhanVien { get; set; } // dac trung cho chuc vu ( cap quyen cho moi nhan vien)
        private QLKSEntities db = new QLKSEntities();
        private QL_TaiKhoan qltk = new QL_TaiKhoan();
        private Form currentChildForm;
        public Main()
        {
            InitializeComponent();
        }

        public Main(string Id)
        {
            IDNhanVien = Id;
            InitializeComponent();
            PhanQuyen(GetTKView(IDNhanVien));
        }
        
        // Lay tai khoan dang nhap hien tai voi dang TaiKhoanView
        public  TaiKhoanView GetTKView(string Id)
        {
            TaiKhoanView tk = new TaiKhoanView();
            foreach(TaiKhoanView i in qltk.getAllTaiKhoan())
            {
                if(i.IdNhanVien == Id)
                {
                    tk = i;
                    break;
                }
            }
            return tk;
        }
        
        // Phan Quyen
        public void PhanQuyen(TaiKhoanView tk)
        {
            if(tk.ChucVu == "Admin")
            {

            }
            else if (tk.ChucVu == "NhanVien")
            {
                button9.Visible = false;
                button9.Enabled = false;
                button3.Visible = false;
                button3.Enabled = false;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //FormDatPhong datphong = new FormDatPhong();
            //datphong.ShowDialog();
            //datphong = null;
            //this.Show();
            OpenChildForm(new FormDatPhong());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //DanhSachKhachHang dskh = new DanhSachKhachHang();
            //dskh.ShowDialog();
            //dskh = null;
            //this.Show();
            OpenChildForm(new DanhSachKhachHang());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //QLNguoiDung qlnd = new QLNguoiDung();
            //qlnd.ShowDialog();
            //qlnd = null;
            //this.Show();
            OpenChildForm(new QLNguoiDung());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //FormHome fh = new FormHome();
            //fh.ShowDialog();
            //fh = null;
            //this.Show();
            OpenChildForm(new FormHome());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //FormBaoCao bc = new FormBaoCao();
            //bc.ShowDialog();
            //bc = null;
            //this.Show();
            OpenChildForm(new FormBaoCao());
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {          
            OpenChildForm(new FormLichSuDangNhap());
        }
        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDeskTop.Controls.Add(childForm);
            panelDeskTop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MenuUser.Show(pictureBox3, pictureBox3.Width, 0);
        }
    }
}
