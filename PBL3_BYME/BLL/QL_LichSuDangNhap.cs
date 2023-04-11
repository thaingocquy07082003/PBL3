using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_BYME.BLL
{
    public class QL_LichSuDangNhap
    {
         private QLKSEntities db = new QLKSEntities();
        public string getnewIDLichSuDangNhap()
        {
            int idtt = 0;
            List<string> data = new List<string>();
            foreach (var i in db.LichSuDangNhaps.Select(p => p).OrderBy(p => p.IdLichSu))
            {
                idtt++;
            }
            idtt++;
            return "LS" + idtt.ToString();
        }

        // Them 1 Hoat Dong Vao LichSuHoatDong
        public void addLichSu(string idNhanVien, bool TrangThai)
        {
            LichSuDangNhap lichSuDangNhap = new LichSuDangNhap();
            lichSuDangNhap.IdLichSu = getnewIDLichSuDangNhap();
            lichSuDangNhap.IdNhanVien = idNhanVien;
            lichSuDangNhap.ThoiGian = DateTime.Now;
            lichSuDangNhap.TrangThai = TrangThai;
            db.LichSuDangNhaps.Add(lichSuDangNhap);
            db.SaveChanges();
        }
    }
}
