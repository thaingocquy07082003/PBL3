using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3_BYME.DTO;
namespace PBL3_BYME.BLL
{
    public class QL_TaiKhoan
    {
        private QLKSEntities db = new QLKSEntities();

        // Lay thong tin tat ca cac tai khoan view 
        public List<TaiKhoanView> getAllTaiKhoan()
        {
            List<TaiKhoanView> data = new List<TaiKhoanView>();
            foreach (var i in db.NhanViens.ToList())
            {
                data.Add(GetTaiKhoanView(i));
            }
            return data;
        }


        // Lay Thong tin tai khoan voi input la 1 nhan vien
        public TaiKhoanView GetTaiKhoanView(NhanVien i)
        {
            TaiKhoanView taiKhoanView = new TaiKhoanView();
            taiKhoanView.IdNhanVien = i.IdNhanVien;
            taiKhoanView.TenDangNhap = i.TaiKhoan.TenDangNhap;
            taiKhoanView.ChucVu = i.ChucVu.TenChucVu;
            return taiKhoanView;
        }


        // Check thong tin tai khoan co hop le de dang nhap hay ko
        public bool Check(string tk, string pass)
        {
            List<TaiKhoan> list = new List<TaiKhoan>();
            foreach(var i in db.TaiKhoans.ToList())
            {
                list.Add(i);
            }
            foreach(TaiKhoan t in list)
            {
                if(t.TenDangNhap == tk && t.MatKhau == pass)
                {
                    return true;
                }
            }
            return false;
        }

        // Lay IdChucVu de phan quyen theo tendangnhap
        public string GetChucVu(string tk)
        {
            string s ="";
            foreach(TaiKhoanView t in getAllTaiKhoan())
            {
                if(t.TenDangNhap == tk)
                {
                    s = t.ChucVu;
                    break;
                }
            }
            return s;
        }

        

    }
}
