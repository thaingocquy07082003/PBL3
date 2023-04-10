using PBL3_BYME.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PBL3_BYME
{
    public partial class DanhSachKhachHang : Form
    {
        public DanhSachKhachHang()
        {
            InitializeComponent();
            showCBB();
        }
        private void showCBB()
        {
            comboBox1.Items.Add("Nam");
            comboBox1.Items.Add("Nữ");
            string[] item = new string[] { "Mã khách hàng", "Tên khách hàng", "Quốc tịch" };
            comboBox2.Items.AddRange(item);
            comboBox2.SelectedIndex = 0;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        }private void showKH()
        {
            QLKS_DB dB = new QLKS_DB();
            dataGridView1.DataSource = dB.KhachHangs.ToList();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            showKH();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (QLKhachHang_BLL.Instance.findKhachHangById(textBox1.Text) == null)
            {
                try
                {
                    addOrUpdate(textBox1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bạn cần phải nhập đầy đủ thông tin");
                }
            }
            else
            {
                MessageBox.Show("Mã khách hàng này đã tồn tại");
            }
        }
        private void addOrUpdate(string id)
        {
            KhachHangs khachHang = new KhachHangs();
            khachHang.IdKhachHang = textBox1.Text;
            khachHang.CMND = textBox3.Text;
            khachHang.Ten = textBox2.Text;
            khachHang.GhiChu = textBox6.Text;
            khachHang.QuocTich = textBox5.Text;
            khachHang.SDT = textBox4.Text;
            if (comboBox1.SelectedIndex == 0)
            {
                khachHang.GioiTinh = true;
            }
            else
            {
                khachHang.GioiTinh = false;
            }
            QLKhachHang_BLL.Instance.addOrUpdate(khachHang);
            showKH();
        }
    }
}
