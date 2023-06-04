using PBL3_BYME.BLL;
using PBL3_BYME.DTO;
using PBL3_BYME.VIEW;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace PBL3_BYME
{
    public partial class FormBaoCao : Form
    {
        public QLKSEntities db = new QLKSEntities();
        public BaoCao_BLL tmp = new BaoCao_BLL();
        public List<BaoCao> data = new List<BaoCao>();
        public FormBaoCao()
        {
            InitializeComponent();
            setCBB();
        }
        public void setCBB()
        {
            for (int i = 2018; i <= 2023; i++)
            {
                comboBox2.Items.Add(new CBBItem { Value = "" + i, Text = "Năm " + i });
            }
            comboBox1.Items.Add(new CBBItem { Value = "0", Text = "All" });
            for (int i = 1; i <= 12; i++)
            {
                comboBox1.Items.Add(new CBBItem { Value = "" + i, Text = "Tháng " + i });
            }
        }
        public void show()
        {
            
            int nam = comboBox2.SelectedIndex + 2018;
            int thang = comboBox1.SelectedIndex;
            if (thang == 0)
            {
                data = tmp.getAllBaoCao(thang, nam);
            }
            else { data = tmp.getBaoCaoByThang(thang, nam); }
            dataGridView1.DataSource = data;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Dispose();
            List<ThongKe_DoanhThuTheoThang> dttt = new List<ThongKe_DoanhThuTheoThang>();
            foreach (BaoCao i in data)
            {
                dttt.Add(new ThongKe_DoanhThuTheoThang
                {
                    thang = i.ThangNam,
                    doanhthu = i.TongDoanhThu
                });
            }
            List<ThongKe_DichVu> tkdv = new List<ThongKe_DichVu>();
            List<string> namedv = db.DichVus.Select(p => p.TenDichVu).ToList();
            foreach (string name in namedv)
            {
                tkdv.Add(new ThongKe_DichVu
                {
                    tendv = name,
                    lansd = tmp.SoLanSDDV(name)
                });
            }

            Graphic detail = new Graphic(tkdv, dttt);
            detail.Show();
        }

 
    }
}
