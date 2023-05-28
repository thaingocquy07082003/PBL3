using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3_BYME.DTO;
namespace PBL3_BYME.BLL
{
    public class TraPhong_BLL
    {
        QLKSEntities db = new QLKSEntities();

        // Lay ra cac Dich vu 
        public List<DichVu> GetAllDichVu()
        {
            List<DichVu> data = new List<DichVu>();
            foreach (DichVu i in db.DichVus.ToList())
            {
                data.Add(i);
            }
            return data;
        }

        // Chiteietdichvu => chitietdichvu_view
        public ChiTietDichVu_View View(ChiTietSuDungDichVu ct)
        {
            return new ChiTietDichVu_View
            {
                ID_ChiTietSuDungDichVu = ct.ID_ChiTietSuDungDichVu,
                ID_Phong = ct.ID_Phong,
                ID_DichVu = ct.ID_DichVu,
                ID_HoaDon = ct.ID_HoaDon,
                NgaySuDung = ct.NgaySuDung,
                SoLuong = ct.SoLuong,
                TrangThai = ct.TrangThai
            };
        }

        //  lay danh sach cac chi tiet su dung dich vu ( cac dich vu da va dang dc use)
        public List<ChiTietDichVu_View> GetAllChiTietDV()
        {
            List<ChiTietDichVu_View> data = new List<ChiTietDichVu_View>();
            foreach (ChiTietSuDungDichVu i in db.ChiTietSuDungDichVus.ToList())
            {
                data.Add(View(i));
            }
            return data;
        }

        // Tra ve doi tuong la 1 hoa don tu 1 IdHoaDon cho truoc 
        public HoaDon GetHoaDonByIdHoaDon(string Id)
        {
            HoaDon hd = new HoaDon();
            foreach(HoaDon i in db.HoaDons.ToList())
            {
                if(i.IdHoaDon == Id)
                {
                    hd = i;
                }
            }
            return hd;
        }

        // Lay ten khach hang theo ID khach hang
        public string GetNameKhachHang(string id)
        {
            string s = "";
            foreach(KhachHang i in db.KhachHangs.ToList())
            {
                if(i.IdKhachHang == id)
                {
                    s = i.Ten;
                }
            }
            return s;
        }

        // Lay IdBook boi Id khach hang va id nhan vien
        public string GetIdBookByIdKH(string idkh, string idnv)
        {
            string s = "";
            foreach(Book i in db.Books.ToList())
            {
                if(i.IdKhachHang == idkh && i.IdNhanVien == idnv)
                {
                    s = i.IdBook;
                }
            }
            return s;
        }

        // Lay Id phong trong chitietbook boi Id book 
        public string GetIdPhong(string idbook)
        {
            string s = "";
            foreach(ChiTietBook i in db.ChiTietBooks.ToList())
            {
                if(i.IdBook == idbook && i.TrangThai == false)
                {
                    return i.IdPhong;
                }
            }
            return s;
        }

        // Lay Ten phong tu Id phong
        public string GetNamePhong(string id)
        {
            string s = "";
            foreach(PHONG i in db.PHONGs.ToList())
            {
                if(i.IdPhong == id)
                {
                    return i.TenPhong;
                }
            }
            return s;
        }

        // Lay ten nhan vien
        public string GetNameNV(string idnv)
        {
            string s = "";
            foreach(NhanVien i in db.NhanViens.ToList())
            {
                if(i.IdNhanVien == idnv)
                {
                    return i.Ten;
                }
            }
            return s;
        }

        // Lay ngay thue 
        public DateTime GetCheckInDay(string Idbook)
        {
            DateTime dt = DateTime.Now;
            foreach(ChiTietBook i in db.ChiTietBooks.ToList())
            {
                if(i.IdBook == Idbook)
                {
                    return Convert.ToDateTime(i.NgayCheckInPhong);
                }
            }
            return dt;
        }

        // Lay Ngay tra 
        public DateTime GetCheckOutDay(string Idbook)
        {
            DateTime dt = DateTime.Now;
            foreach (ChiTietBook i in db.ChiTietBooks.ToList())
            {
                if (i.IdBook == Idbook)
                {
                    return Convert.ToDateTime(i.NgayCheckOutPhong);
                }
            }
            return dt;
        }

        // Lay don gia phong
        public int GetCostOfRoom(string tenphong)
        {
            int cost = 0;
            foreach(PHONG i in db.PHONGs.ToList())
            {
                if(i.TenPhong == tenphong)
                {
                    cost = Convert.ToInt32(i.DonGiaPhong);
                }
            }
            return cost;
        }

        // Lay chi tiet thue phong
        public ChiTietThuePhong Getchitiet(string idphong)
        {
            return db.ChiTietThuePhongs.Where(p => p.IdPhong == idphong && p.TrangThai == false).FirstOrDefault();
        }

        // Lay Gia cua dich vu 
        public string GetGiaDV(string iddichvu)
        {
            string s = "";
            foreach(DichVu i in db.DichVus.ToList())
            {
                if(i.IdDichVu == iddichvu)
                {
                    return i.DonGia;
                }
            }
            return s;
        }

        // lay gia dich vu ung voi Id Phong dang dc thue
        public long GetCostDV(string idphong)
        {
            long cost = 0;
            List<ChiTietSuDungDichVu> chiTietSuDungDichVus = db.ChiTietSuDungDichVus.Where(p => p.ID_Phong == idphong && p.TrangThai == false).ToList();
            foreach(ChiTietSuDungDichVu i in chiTietSuDungDichVus)
            {
                cost += (long)(i.SoLuong * Convert.ToInt32(i.DichVu.DonGia));
            }
            return cost;
        }

        // Lay gia Vat dung lam hu
        public long GetCostVD(string idHOADON)
        {
            long cost = 0;
            List<LamHu> lamHus = db.LamHus.Where(p => p.IdPhong == idHOADON).Select(p => p).ToList();
            foreach(LamHu i in lamHus)
            {
                if (i.IdHoaDon == idHOADON)
                {
                    cost += (long)(i.SoLuongLamHu * i.LoaiVatDung.DonGia);
                }
            }
            return cost;
        }
    }
}
