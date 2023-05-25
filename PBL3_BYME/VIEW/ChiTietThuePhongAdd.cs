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
    public partial class ChiTietThuePhongAdd : Form
    {
        public string ID_Phong { get; set; }
        public string ID_HoaDon { get; set; }
        QLKSEntities db = new QLKSEntities();
        BLL_ChiTietDichVu ctdv = new BLL_ChiTietDichVu();
        public ChiTietThuePhongAdd(string id, string idphong)
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
            comboBox1.Items.Add("true");
            comboBox1.Items.Add("false");
        }
        public void Display()
        {
            dataGridView1.DataSource = ctdv.GetAllDichVu();
            dataGridView2.DataSource = ctdv.GetAllChiTietDV();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataGridViewRow i = dataGridView1.SelectedRows[0];
            ChiTietSuDungDichVu chitiet = new ChiTietSuDungDichVu
            {
                ID_ChiTietSuDungDichVu = Convert.ToInt32(textBox1.Text),
                ID_Phong = ID_Phong,
                ID_DichVu = i.Cells["IdDichVu"].Value.ToString(),
                ID_HoaDon = ID_HoaDon,
                NgaySuDung = dateTimePicker1.Value,
                SoLuong = Convert.ToInt32(textBox5.Text),
                TrangThai = Convert.ToBoolean(comboBox1.SelectedItem.ToString()),
            };
            ctdv.ADD(chitiet);
            Display();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow i in dataGridView2.SelectedRows)
            {
                ctdv.DELETE(Convert.ToInt32(i.Cells["ID_ChiTietSuDungDichVu"].Value.ToString()));
            }
            Display();
        }
    }
}
