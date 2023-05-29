using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3_BYME.DTO;
namespace PBL3_BYME.BLL
{
    public  class ChonHoaDon_BLL
    {
        QLKSEntities db = new QLKSEntities();
        public List<HoaDon_View> GetAllHoaDon()
        {
            List<HoaDon_View> list = new List<HoaDon_View>();
            foreach(HoaDon i in db.HoaDons.ToList())
            {
                if (i.TinhTrang == false)
                {
                    list.Add(new HoaDon_View
                    {
                        IdHoaDon = i.IdHoaDon,
                        TenKhachHang = i.KhachHang.Ten,
                        SDT = i.KhachHang.SDT,
                        CCCD = i.KhachHang.CMND,
                        TenPhong = GetNamePhong(GetIDPhong(i.IdHoaDon))
                    });
                }
            }
            return list;
        }

        // lAY ten phong theo id phong
        public string GetNamePhong(string idphong)
        {
            string s = "";
            foreach(PHONG i in db.PHONGs.ToList())
            {
                if(i.IdPhong == idphong)
                {
                    return i.TenPhong;
                }
            }
            return s;
        }

        // lay Id phong bang id hoa don
        public string GetIDPhong(string idhoadon)
        {
            string s = "";
            HoaDon hoadon = db.HoaDons.Where(p => p.IdHoaDon == idhoadon && p.TinhTrang == false).FirstOrDefault();
            Book book = db.Books.Where(p => p.IdKhachHang == hoadon.IdKhachHang && p.IdNhanVien == hoadon.IdNhanVien && p.TrangThai == false).FirstOrDefault();
            foreach (ChiTietBook i in db.ChiTietBooks.ToList())
            {
                if (i.IdBook == book.IdBook)
                {
                    return i.IdPhong;
                }
            }
            return s;
        }


    }
}
