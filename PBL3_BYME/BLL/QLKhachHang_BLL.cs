using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_BYME.BLL
{
    public class QLKhachHang_BLL
    {
        private QLKS_DB db = new QLKS_DB();
        private static QLKhachHang_BLL _Instance;
        public static QLKhachHang_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new QLKhachHang_BLL();
                }
                return _Instance;
            }
            set { }
        }
        public KhachHangs findKhachHangById(string id)
        {
            var query = db.KhachHangs.Select(p => p).ToList();
            foreach (var item in query)
            {
                if (id == item.IdKhachHang)
                {
                    return item;
                }
            }
            return null;
        }
        public void addOrUpdate(KhachHangs khachHang)
        {
            if (findKhachHangById(khachHang.IdKhachHang) != null)
            {
                var t = db.KhachHangs.Where(p => p.IdKhachHang == khachHang.IdKhachHang).FirstOrDefault();
                t.CMND = khachHang.CMND;
                t.SDT = khachHang.SDT;
                t.Ten = khachHang.Ten;
                t.GioiTinh = khachHang.GioiTinh;
                t.GhiChu = khachHang.GhiChu;
                t.QuocTich = khachHang.QuocTich;
                db.SaveChanges();
            }
            else
            {
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
            }
        }
    }
}
