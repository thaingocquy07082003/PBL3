using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_BYME.BLL
{
    public class QL_NhanVien
    {
        private QLKSEntities db = new QLKSEntities();
        // Lay danh sach nhan vien trong csdl
        public List<NhanVien> GetAllNhanVien()
        {
            List<NhanVien> result = new List<NhanVien>();
            foreach (NhanVien i in db.NhanViens.ToList())
            {
                result.Add(i);
            }
            return result;
        }

        // Lay Danh sach cac chuc vu
        public List<string> GetAllChucVu()
        {
            return db.ChucVus.Select(p => p.TenChucVu).ToList();
        }

        // Lay danh sach nhung nhan vien co ten ...
        public List<NhanVien> GetNVByName(string name)
        {
            List<NhanVien> nhanViens = new List<NhanVien>();
            foreach (NhanVien i in db.NhanViens.ToList())
            {
                if (i.Ten == name || i.Ten.Contains(name) == true)
                {
                    nhanViens.Add(i);
                }
            }
            return nhanViens;
        }

        // Sap xep 
        public List<NhanVien> Sort(string Mode)
        {
            List<NhanVien> data = new List<NhanVien>();
            if (Mode == "Ten")
            {
                data.AddRange(db.NhanViens.OrderBy(p => p.Ten).ToArray());
            }
            else
            {
                data.AddRange(db.NhanViens.OrderBy(p => p.IdNhanVien).ToArray());
            }
            return data;
        }

        // Xoa nhan vien
        public void delete(string id)
        {
            foreach (NhanVien i in db.NhanViens.ToList())
            {
                if (i.IdNhanVien == id)
                {
                    try
                    {
                        db.NhanViens.Remove(i);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                }
            }
        }

        // Check Thong tin Nhan vien ton tai hay chua 
        public bool Check(string idnv)
        {
            foreach (NhanVien i in db.NhanViens.ToList())
            {
                if (i.IdNhanVien == idnv)
                {
                    return true;
                }
            }
            return false;
        }

        // ADD Nhan Vien 
        public void ADD(NhanVien nv)
        {
            db.NhanViens.Add(nv);
            db.SaveChanges();
        }

        // UPDATE Nhan Vien
        public void UPDATE(NhanVien nv)
        {
            try
            {
                NhanVien t = db.NhanViens.Where(p => p.IdNhanVien == nv.IdNhanVien).FirstOrDefault();
                t.IdChucVu = nv.IdChucVu;
                t.IdTaiKhoan = nv.IdTaiKhoan;
                t.Ten = nv.Ten;
                t.GioiTinh = nv.GioiTinh;
                t.CMND = nv.CMND;
                t.SDT = nv.SDT;
                t.DiaChi = nv.DiaChi;
                t.NgayVaoLam = nv.NgayVaoLam;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
