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
        public List<BaoCao> getAllBaoCao(int thang,int nam)
        { 
            List<BaoCao> data = new List<BaoCao>();
            int th = 1;
            while (th<=12 )
            {
                string id = th.ToString() + nam.ToString();
                //DateTime dt = new DateTime(nam, thang, ngay);
                String thangnam = th.ToString() + "/" + nam.ToString();
                data.Add(new BaoCao
                {
                    IdBaoCao = id,
                    ThangNam = thangnam,
                    SoLuotThuePhongBT = SoLuotThuePhongBT(thang, nam),
                    SoLuotThuePhongVIP = SoLuotThuePhongVip(thang, nam),
                    DoanhThuDV = TongDoanhThuDichVu(thang, nam ),
                    DoanhThuPhong = TongDoanhThuPhong(thang, nam),
                    TongDoanhThu = TongDoanhThuDichVu(thang, nam) + TongDoanhThuPhong(thang, nam),
                    SoNgayThuePhong = SoLuotThuePhongBT(thang, nam) + SoLuotThuePhongVip(thang, nam)


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
                IdBaoCao =thang.ToString() + nam.ToString(),
                ThangNam = ngaythang,
                SoLuotThuePhongBT = SoLuotThuePhongBT(thang,nam),
                SoLuotThuePhongVIP = SoLuotThuePhongVip(thang, nam),
                DoanhThuDV = TongDoanhThuDichVu(thang, nam),
                DoanhThuPhong = TongDoanhThuPhong(thang, nam),
                TongDoanhThu = TongDoanhThuDichVu(thang, nam) + TongDoanhThuPhong(thang, nam),
                SoNgayThuePhong = SoLuotThuePhongBT(thang, nam) + SoLuotThuePhongVip(thang, nam)
            });
            return data;
        }
        public int TongDoanhThuDichVu(int thang,int nam)
        {
            int tongTien = 0;
            foreach (var i in db.ChiTietSuDungDichVus.Select(p=>p))
            {
                if (i.NgaySuDung.Value.Month == thang && i.NgaySuDung.Value.Year == nam)
                {
                    //tongTien += i.SoLuong * Convert.ToInt32(i.DichVu.DonGia);
                }

            }
            return tongTien;
        }
        public int TongDoanhThuPhong(int thang,int nam)
        {
            int tongtien = 0;
            foreach (var i in db.ChiTietThuePhongs.Select(p => p))
            {
                if (i.NgayCheckIn.Value.Month == thang && i.NgayCheckIn.Value.Year == nam)
                {
                    tongtien += ((i.NgayCheckOut - i.NgayCheckIn).Value.Days + 1)*i.DonGia.Value;
                }
            }
            return tongtien;
        }
        public int SoLuotThuePhongBT(int thang,int nam)
        {
            int TongNgay = 0;
            foreach (var i in db.ChiTietThuePhongs.Select(p=>p))
            {
                if (i.NgayCheckIn.Value.Month == thang && i.NgayCheckIn.Value.Year == nam)
                {
                    TongNgay ++;
                }
            }
            return TongNgay;
        }
        public int SoLuotThuePhongVip(int thang, int nam)
        {
            int songay = 0;
            foreach (var i in db.ChiTietThuePhongs.Select(p => p))
            {
                if (i.NgayCheckIn.Value.Month == thang && i.NgayCheckIn.Value.Year == nam)
                {
                    songay++;
                }
            }
            return songay;
        }
    }
}
