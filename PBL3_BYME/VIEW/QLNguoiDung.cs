using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PBL3_BYME.BLL;
namespace PBL3_BYME
{
    public partial class QLNguoiDung : Form
    {
        private QL_NhanVien qlnv = new QL_NhanVien();
        private QL_TaiKhoan qltk = new QL_TaiKhoan();
        public QLNguoiDung()
        {
            InitializeComponent();
            Display();
            SetCBB();
        }
        public void SetCBB()
        {
            comboBox1.Items.Add("Nam");
            comboBox1.Items.Add("Nu");
            // setup cho cbb2
            comboBox2.Items.AddRange(qlnv.GetAllChucVu().ToArray());
            // setup cho cbb3 
            comboBox3.Items.Add("Ten");
            comboBox3.Items.Add("Ma Nhan Vien");
        }

        public void Display()
        {
            dataGridView1.DataSource = qlnv.GetAllNhanVien();
        }
        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Mode = comboBox3.SelectedItem.ToString();
            dataGridView1.DataSource = qlnv.Sort(Mode);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox9.Text = "";
            Display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox8.Text;
            dataGridView1.DataSource = qlnv.GetNVByName(name);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach(DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    qlnv.delete(i.Cells["IdNhanVien"].Value.ToString());
                }
            }
            Display();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            textBox1.Text = row.Cells["IdNhanVien"].Value.ToString();
            textBox2.Text = row.Cells["Ten"].Value.ToString();
            textBox3.Text= row.Cells["CMND"].Value.ToString();
            textBox4.Text = row.Cells["SDT"].Value.ToString();
            if (Convert.ToBoolean(row.Cells["GioiTinh"].Value) == true)
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.SelectedIndex = 1;
            }
            textBox5.Text = row.Cells["DiaChi"].Value.ToString();
            int index = comboBox2.FindStringExact(qlnv.GetTenCV(row.Cells["IdChucVu"].Value.ToString()));
            if (index != -1)
            {
                comboBox2.SelectedIndex = index;
            }
            dateTimePicker1.Value = Convert.ToDateTime(row.Cells["NgayVaoLam"].Value);
            string idtk = row.Cells["IdTaiKhoan"].Value.ToString();
            textBox9.Text = idtk;
            textBox6.Text = qltk.GetTaiKhoanById(idtk).TenDangNhap.ToString();
            textBox7.Text = qltk.GetTaiKhoanById(idtk).MatKhau.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien
            {
                IdNhanVien = textBox1.Text,
                IdChucVu = qlnv.GetIdChuvu(comboBox2.SelectedItem.ToString()),
                IdTaiKhoan = textBox9.Text,
                Ten = textBox2.Text,
                CMND = textBox3.Text,
                SDT = textBox4.Text,
                DiaChi = textBox5.Text,
                NgayVaoLam = Convert.ToDateTime(dateTimePicker1.Value),
            };
            if(comboBox1.SelectedItem.ToString() == "Nam")
            {
                nv.GioiTinh = true;
            }
            else
            {
                nv.GioiTinh = false;
            }
            TaiKhoan tk = new TaiKhoan
            {
                IdTaiKhoan = textBox9.Text,
                TenDangNhap = textBox6.Text,
                MatKhau = textBox7.Text,
                TrangThai = false
            };
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn tiếp tục?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Code xử lý khi người dùng chọn Yes
                if(qltk.Check(tk.TenDangNhap,tk.MatKhau) == true)
                {
                    MessageBox.Show("Tai Khoan cua ban da ton tai xin vui long them moi tai khoan khac!");
                }
                else
                {
                    qltk.ADD(tk);
                    if(qlnv.Check(nv.IdNhanVien) == true)
                    {
                        qlnv.UPDATE(nv);
                    }
                    else
                    {
                        qlnv.ADD(nv);
                    }
                }
                Display();
            }
            else
            {
                // Code xử lý khi người dùng chọn No
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien
            {
                IdNhanVien = textBox1.Text,
                IdChucVu = qlnv.GetIdChuvu(comboBox2.SelectedItem.ToString()),
                IdTaiKhoan = textBox9.Text,
                Ten = textBox2.Text,
                CMND = textBox3.Text,
                SDT = textBox4.Text,
                DiaChi = textBox5.Text,
                NgayVaoLam = Convert.ToDateTime(dateTimePicker1.Value),
            };
            if (comboBox1.SelectedItem.ToString() == "Nam")
            {
                nv.GioiTinh = true;
            }
            else
            {
                nv.GioiTinh = false;
            }
            TaiKhoan tk = new TaiKhoan
            {
                IdTaiKhoan = textBox9.Text,
                TenDangNhap = textBox6.Text,
                MatKhau = textBox7.Text,
                TrangThai = false
            };
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn tiếp tục?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Code xử lý khi người dùng chọn Yes
                if (qltk.Check(tk.TenDangNhap, tk.MatKhau) == true)
                {
                    qltk.UPDATE(tk);
                    qlnv.UPDATE(nv);
                    Display();
                }
                else
                {
                    
                }
            }
            else
            {
                // Code xử lý khi người dùng chọn No
            }
        }
    }
}
