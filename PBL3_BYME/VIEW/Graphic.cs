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

namespace PBL3_BYME.VIEW
{
    public partial class Graphic : Form
    {
        private List<ThongKe_DichVu> tkdv = new List<ThongKe_DichVu>();
        private List<ThongKe_DoanhThuTheoThang> tktt = new List<ThongKe_DoanhThuTheoThang>();
        private List<ThongKe_DoanhThuTheoThang> dttt;

        public Graphic(List<ThongKe_DichVu> dv, List<ThongKe_DoanhThuTheoThang> tt)
        {
            InitializeComponent();
            tkdv = dv;
            tktt = tt;
            BieuDoCot();
            BieuDoTron();
        }

        public Graphic(List<ThongKe_DoanhThuTheoThang> dttt, List<ThongKe_DichVu> tkdv)
        {
            this.dttt = dttt;
            this.tkdv = tkdv;
        }

        public void BieuDoCot()
        {
            foreach (ThongKe_DoanhThuTheoThang i in tktt)
            {
                ChartBDC.Series["ChartBDC"].Points.AddXY(i.thang, i.doanhthu);
            }
        }

        public void BieuDoTron()
        {
            ChartBDT.DataSource = tkdv;
            ChartBDT.Series["ChartBDT"].XValueMember = "tendv";
            ChartBDT.Series["ChartBDT"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            ChartBDT.Series["ChartBDT"].YValueMembers = "lansd";
            ChartBDT.Series["ChartBDT"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
        }
    }
}