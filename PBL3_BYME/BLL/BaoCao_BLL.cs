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
                    SoLuotThuePhongBT = SoNgayThuePhongBT(DateTime.Now),
                    SoLuotThuePhongVIP = SoNgayThuePhongVip(DateTime.Now),
                    DoanhThuDV = TongDoanhThuDichVu(DateTime.Now),
                    DoanhThuPhong = TongDoanhThuPhong(DateTime.Now),
                    TongDoanhThu = TongDoanhThuDichVu(DateTime.Now) + TongDoanhThuPhong(DateTime.Now),
                    SoNgayThuePhong = SoNgayThuePhongBT(DateTime.Now) + SoNgayThuePhongVip(DateTime.Now)


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
                SoLuotThuePhongBT = SoNgayThuePhongBT(thang,nam),
                SoLuotThuePhongVIP = SoNgayThuePhongVip(thang, nam),
                DoanhThuDV = TongDoanhThuDichVu(thang, nam),
                DoanhThuPhong = TongDoanhThuPhong(thang, nam),
                TongDoanhThu = TongDoanhThuDichVu(thang, nam) + TongDoanhThuPhong(thang, nam),
                SoNgayThuePhong = SoNgayThuePhongBT(thang, nam) + SoNgayThuePhongVip(thang, nam)
            });
            return data;
        }
        public int TongDoanhThuDichVu(int thang ,int nam)
        {
            int tongtien = 0;
            return tongtien;
        }
        public int TongDoanhThuPhong(int thang,int nam)
        {
            int tongtien = 0;
            return tongtien;
        }
        public int SoNgayThuePhongBT(int thang,int nam)
        {
            int songay = 0;
            return songay;
        }
        public int SoNgayThuePhongVip(int thang, int nam)
        {
            int songay = 0;
            return songay;
        }
    }
}
