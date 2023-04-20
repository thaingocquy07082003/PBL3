using PBL3_BYME.BLL;
using PBL3_BYME.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3_BYME
{
    public partial class DanhSachKhachHang : Form
    {
        private QLKSEntities db = new QLKSEntities();
        private QL_KhachHang tmp=new QL_KhachHang();
        public DanhSachKhachHang()
        {
            InitializeComponent();
            showCBB();
        }
        public void showKH()
        {
            List<KhachHangView> data = new List<KhachHangView>();
            data = tmp.getAllKhachHang();

        }
        private void showCBB()
        {
            comboBox1.Items.Add("Nam");
            comboBox1.Items.Add("Nữ");
            comboBox2.Items.Add("Mã khách hàng");
            comboBox2.Items.Add("Tên khách hàng");
            comboBox2.Items.Add("Quốc tịch");
            comboBox2.SelectedIndex = 0;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tmp.findKhachHangById(textBox1.Text) == null)
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
            KhachHang khachHang = new KhachHang();
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
            tmp.addOrUpdate(khachHang);
            showKH();
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    DialogResult confirmResult = MessageBox.Show("Bạn có chắc muốn xoá khách hàng mã số " + i.Cells["IdKhachHang"].Value.ToString() + " không?", "Cảnh báo", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        tmp.delete(i.Cells["IdKhachHang"].Value.ToString());
                    }
                    else
                    {

                    }
                }
            }
            showKH();
        }
        private void showInfoKH(string id)
        {
            KhachHang khachHang = tmp.findKhachHangById(id);
            if (khachHang != null)
            {
                textBox1.Text = khachHang.IdKhachHang;
                textBox1.Enabled = false;
                textBox3.Text = khachHang.CMND;
                textBox2.Text = khachHang.Ten;
                textBox6.Text = khachHang.GhiChu;
                textBox5.Text = khachHang.QuocTich;
                textBox4.Text = khachHang.SDT;
                if ((bool)khachHang.GioiTinh)
                {
                    comboBox1.SelectedIndex = 0;
                }
                else
                {
                    comboBox1.SelectedIndex = 1;
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            showInfoKH(dataGridView1.SelectedRows[0].Cells["IdKhachHang"].Value.ToString());
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            List<KhachHangView> data = new List<KhachHangView>();
            data = tmp.getAllKhachHang();
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem== "Tên khách hàng")
            {
                data.Sort((x, y) => x.Ten.CompareTo(y.Ten));
            }
            if(cb.SelectedItem=="Quốc tịch")
            {
                data.Sort((x, y) => x.QuocTich.CompareTo(y.QuocTich));
            }
            dataGridView1.DataSource = data;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<KhachHangView> data = new List<KhachHangView>();
            string ten=textBox7.Text.ToString();
            data = tmp.getKhachHangByTen(ten);
            dataGridView1.DataSource=data;
        }
    }
}
