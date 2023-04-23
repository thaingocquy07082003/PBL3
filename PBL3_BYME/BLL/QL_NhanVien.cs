using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_BYME.BLL
{
    public  class QL_NhanVien
    {
       private QLKSEntities db = new QLKSEntities();
        // Lay danh sach nhan vien trong csdl
       public List<NhanVien> GetAllNhanVien()
       {
            List<NhanVien> result = new List<NhanVien>();
            foreach(NhanVien i in db.NhanViens.ToList())
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
            foreach(NhanVien i in db.NhanViens.ToList())
            {
                if(i.Ten == name || i.Ten.Contains(name) == true)
                {
                    nhanViens.Add(i);
                }
            }
            return nhanViens;
        }

        // Sap xep theo danh sach Ma Nhan vien cho trc
        public List<NhanVien> Sort(string Mode)
        {
            List<NhanVien> data = new List<NhanVien>();         
            if(Mode == "Ten")
            {
                //data.AddRange(db.NhanViens.))
            }
            return data;
        }
        
         
       
    }
}
