using PBL3_BYME.BLL;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PBL3_BYME.VIEW
{
    public partial class DoiPassWord : Form
    {
        private string IdNhanVien { get; set; }
        private string IdTaiKhoan { get; set; }
        private QL_TaiKhoan qltk = new QL_TaiKhoan();
        public DoiPassWord(string idNhanVien)
        {
            InitializeComponent();
            IdNhanVien = idNhanVien;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IdTaiKhoan = qltk.GetIdTaiKhoan(IdNhanVien);
                TaiKhoan tk = qltk.GetTaiKhoanById(IdTaiKhoan);
                if(textBox1.Text == tk.MatKhau && textBox2.Text !="" && textBox3.Text != "" && textBox2.Text == textBox3.Text)
                {
                    qltk.UPDATE(new TaiKhoan
                    {
                        IdTaiKhoan = IdTaiKhoan,
                        TenDangNhap = tk.TenDangNhap,
                        MatKhau = textBox2.Text,
                        TrangThai = tk.TrangThai
                    });
                    MessageBox.Show("thay doi thanh cong");
                }
                else if(textBox1.Text != tk.MatKhau )
                {
                    MessageBox.Show("Mat khau hien tai da nhap sai");
                }
                else if (textBox2.Text != textBox3.Text)
                {
                    MessageBox.Show("Mat Khau Moi va mat khau lap lai ko giong nhau!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
