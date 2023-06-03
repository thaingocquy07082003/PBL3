using PBL3_BYME.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3_BYME.BLL
{
    public class BaoCao_BLL
    {
        private QLKSEntities db = new QLKSEntities();
        public List<BaoCao> getAllBaoCao(int thang, int nam)
        {
            List<BaoCao> data = new List<BaoCao>();
            int th = 1;
            while (th <= 12)
            {
                string id = th.ToString() + nam.ToString();
                //DateTime dt = new DateTime(nam, thang, ngay);
                String thangnam = th.ToString() + "/" + nam.ToString();
                data.Add(new BaoCao
                {
                    IdBaoCao = id,
                    ThangNam = thangnam,
                    SoLuotThuePhongBT = SoLuotThuePhongBT(th, nam),
                    SoLuotThuePhongVIP = SoLuotThuePhongVip(th, nam),
                    DoanhThuDV = TongDoanhThuDichVu(th, nam),
                    DoanhThuPhong = TongDoanhThuPhong(th, nam),
                    TongDoanhThu = TongDoanhThuDichVu(th, nam) + TongDoanhThuPhong(th, nam),
                    SoNgayThuePhong = SoLuotThuePhongBT(th, nam) + SoLuotThuePhongVip(th, nam)


                });
                th++;
            }
            return data;
        }
        public List<BaoCao> getBaoCaoByThang(int thang, int nam)
        {
            List<BaoCao> data = new List<BaoCao>();
            String ngaythang = thang.ToString() + "/" + nam.ToString();
            data.Add(new BaoCao
            {
                IdBaoCao = thang.ToString() + nam.ToString(),
                ThangNam = ngaythang,
                SoLuotThuePhongBT = SoLuotThuePhongBT(thang, nam),
                SoLuotThuePhongVIP = SoLuotThuePhongVip(thang, nam),
                DoanhThuDV = TongDoanhThuDichVu(thang, nam),
                DoanhThuPhong = TongDoanhThuPhong(thang, nam),
                TongDoanhThu = TongDoanhThuDichVu(thang, nam) + TongDoanhThuPhong(thang, nam),
                SoNgayThuePhong = SoLuotThuePhongBT(thang, nam) + SoLuotThuePhongVip(thang, nam)
            });
            return data;
        }
        public int TongDoanhThuDichVu(int thang, int nam)
        {
            int tongTien = 0;
            foreach (var i in db.ChiTietSuDungDichVus.ToList())
            {
                if (i.NgaySuDung.Value.Month == thang && i.NgaySuDung.Value.Year == nam)
                {
                    tongTien += i.SoLuong.Value * GetDonGiaDV(i.ID_DichVu);
                }

            }
            return tongTien;
        }
        public int TongDoanhThuPhong(int thang, int nam)
        {
            int tongtien = 0;
            foreach (var i in db.ChiTietThuePhongs.ToList())
            {
                if (i.NgayCheckIn.Value.Month == thang && i.NgayCheckIn.Value.Year == nam)
                {
                    tongtien +=i.DonGia.Value;
                }
            }
            return tongtien;
        }
        public int SoLuotThuePhongBT(int thang, int nam)
        {
            int songay = 0;
            foreach (var i in db.ChiTietThuePhongs.ToList())
            {
                if (i.NgayCheckIn.Value.Month == thang && i.NgayCheckIn.Value.Year == nam)
                {
                    if (GetLoaiPhong(i.IdPhong) == "normal")
                    {
                        songay++;
                    }
                }
            }
            return songay;
        }
        public int SoLuotThuePhongVip(int thang, int nam)
        {
            int songay = 0;
            foreach (var i in db.ChiTietThuePhongs.ToList())
            {
                if (i.NgayCheckIn.Value.Month == thang && i.NgayCheckIn.Value.Year == nam)
                {
                    if (GetLoaiPhong(i.IdPhong)=="Vip")
                    {
                        songay++;
                    }
                }
            }
            return songay;
        }
        public string GetIDLoaiPhong(string idPhong)
        {
            string s = "";
            foreach (PHONG i in db.PHONGs.ToList())
            {
                if (i.IdPhong == idPhong)
                {
                    return i.IdLoaiPhong;
                }
            }
            return s;
        }
        public string GetLoaiPhong(string id)
        {
            string s = "";
            foreach (LoaiPhong i in db.LoaiPhongs.ToList())
            {
                if (i.IdLoaiPhong == GetIDLoaiPhong(id))
                {
                    return i.TenLoaiPhong;
                }
            }
            return s;
        }
        public int GetDonGiaDV(string id)
        {
            int s =1;
            foreach (DichVu i in db.DichVus.ToList())
            {
                if (i.IdDichVu == id)
                {
                    return Convert.ToInt32(i.DonGia);
                }
            }
            return s;
        }
    }

}