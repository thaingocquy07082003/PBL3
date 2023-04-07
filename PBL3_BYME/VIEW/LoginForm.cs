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

namespace PBL3_BYME
{
    public partial class LoginForm : Form
    {
        private string Id { get; set; }
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // Phan quyen
        public void PhanQuyen(string chucvu)
        {
            if(chucvu == "Admin")
            {
                this.Hide();
                Main main = new Main(chucvu);
                main.ShowDialog();
                main = null;
                this.Show();
            }
            else if (chucvu == "KeToan")
            {
                this.Hide();
                Main main = new Main(chucvu);
                main.ShowDialog();

                main = null;
                this.Show();
            }
            else if (chucvu == "NhanVien")
            {
                this.Hide();
                Main main = new Main();
                main.ShowDialog();

                main = null;
                this.Show();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string tk = textBox1.Text;
            string pass = textBox2.Text;
            QL_TaiKhoan ql = new QL_TaiKhoan();
            if (ql.Check(tk, pass) == true)
            {
                
                foreach (TaiKhoanView t in ql.getAllTaiKhoan())
                {
                    if (t.TenDangNhap == tk)
                    {
                        Id = t.IdNhanVien;
                        break;
                    }
                }
                
                this.Hide();
                Main main = new Main(Id);
                main.ShowDialog();

                main = null;
                this.Show();
            }
            else
            {
                MessageBox.Show("Tai Khoan Hoac Mat Khau sai vui long thu lai !");
            }
        }
    }
}
