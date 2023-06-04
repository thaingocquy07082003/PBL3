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

namespace PBL3_BYME
{
    public partial class TimPhong : Form
    {
        public TimPhong()
        {
            InitializeComponent();
        }
        public void resetRoom()
        {
            foreach (Button i in panel1.Controls)
            {
                i.BackColor = Color.White;
            }
        }
        public void ShowRoom()
        {
            resetRoom();
            DatPhong_BLL datphong = new DatPhong_BLL();
            List<CBBItemPhong> data = datphong.getAllPhong();


            List<string> listRoom = new List<string>();
           
            foreach (CBBItemPhong i in data)
            {
                if (datphong.Check(i.Value, dateTimePicker1.Value, dateTimePicker2.Value) == false)
                {
                    listRoom.Add(i.Text);
                    foreach (Button j in panel1.Controls)
                    {
                        if (j.Text == i.Text)
                        {
                            j.BackColor = Color.Red;
                            break;
                        }
                    }
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value < dateTimePicker1.Value)
            {
                MessageBox.Show("Ngày không hợp lệ !");
                return;
            }
            ShowRoom();
        }
    }
}
