using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_BYME.BLL
{
    public  class Tim_Phong
    {
        QLKSEntities db = new QLKSEntities();
        public List<DateTime> setNgay(string idphong)
        {
            
            List<DateTime> data = new List<DateTime>();
            // string idphong = "1P1";
            var c = db.PHONGs.Find(idphong);
            foreach (var item in c.ChiTietThuePhongs)
            {
                if (item.TrangThai == false)
                {
                    TimeSpan Time = item.NgayCheckOut.Value - item.NgayCheckIn.Value;
                    int songay = Time.Days;
                    for (int i = 0; i <= songay; i++)
                    {
                        data.Add(item.NgayCheckIn.Value.AddDays(+i));
                    }
                }

            }
            foreach (var item in c.ChiTietBooks)
            {
                if (item.TrangThai == false)
                {
                    TimeSpan Time = item.NgayCheckOutPhong.Value - item.NgayCheckInPhong.Value;
                    int songay = Time.Days;
                    for (int i = 0; i <= songay; i++)
                    {
                        data.Add(item.NgayCheckInPhong.Value.AddDays(+i));
                    }
                }

            }
            return data;
        }
    }
}
