using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3_BYME.DTO;
namespace PBL3_BYME.BLL
{
    public class BLL_ChiTietDichVu
    {
        QLKSEntities db = new QLKSEntities();

        // Lay ra cac Dich vu 
        public List<DichVu> GetAllDichVu()
        {
            List<DichVu> data = new List<DichVu>();
            foreach(DichVu i in db.DichVus.ToList())
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
        
        // Lay Ten Khach hang theo Id khach Hang
        public String GetNameKhachHang(string idkh)
        {
            string id = "";
            foreach(KhachHang i in db.KhachHangs.ToList())
            {
                if(i.IdKhachHang == idkh)
                {
                    id = i.Ten;
                    break;
                }
            }
            return id;
        }

        // lay id hach hang ung voi hoa don 
        public string GetIDKhachHang(string IdHoaDon)
        {
            string idkh = "";
            foreach(HoaDon i in db.HoaDons.ToList())
            {
                if(i.IdHoaDon == IdHoaDon)
                {
                    idkh = i.IdKhachHang;
                    break;
                }
            }
            return idkh;
        }
        
        // Lay ten phong
        public string GetNamePhong(string idphong)
        {
            string name = "";
            foreach(PHONG i in db.PHONGs.ToList())
            {
                if(idphong == i.IdPhong)
                {
                    name = i.TenPhong;
                    break;
                }
            }
            return name;
        }
    }
}
