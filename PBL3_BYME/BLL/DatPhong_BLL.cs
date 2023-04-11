using PBL3_BYME.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3_BYME.DTO;
namespace PBL3_BYME.BLL
{
    public class DatPhong_BLL
    {
        private QLKSEntities db = new QLKSEntities();

        // Lay Danh sach tat ca cac phong co trong bang PHONG
       public List<PHONG> GetAllPhong()
        {
            List<PHONG> phongList = db.PHONGs.ToList();
            return phongList;
        }

        // Tu Dong Xu Li Tao Moi 1 IDBook
        public string getNewIDBook()
        {
            List<string> data = new List<string>();
            foreach (var i in db.Books.Select(p => p).OrderBy(p => p.IdBook))
            {
                data.Add(i.IdBook.Substring(1));
            }
            int idtt = Convert.ToInt32(data.Select(v => int.Parse(v)).Max()) + 1;
            return "B" + idtt.ToString();
        }

        // Tu Dong lay 1 IDNhanVien voi trang thai true - tuc la dang co kha nang phuc vu
        public string getIDNhanVien()
        {
            foreach (var i in db.NhanViens.Select(p => p))
            {
                if (i.TaiKhoan.TrangThai == true)
                {
                    return i.IdNhanVien;
                }
            }
            return null;
        }

        // Kiem tra ton tai cua 1 IdBook
        public bool CheckIDBook(string idkhach)
        {
            foreach (var i in db.Books.Select(p => p))
            {
                if (i.IdKhachHang == idkhach && i.TrangThai == false)
                {
                    return true;
                }
            }
            return false;
        }

        // Lay IdBook bang 1 IdKhachHang trong bang Book
        public string GetIdBookByIdKH(string id)
        {
            string str = "";
            foreach(var i in db.Books.ToList())
            {
                if(i.IdKhachHang == id && i.TrangThai == false)
                {
                    str = i.IdBook.ToString();
                }
            }
            return str;
        }

        // Lay IDPhong bang ten phong tuong ung
        public string GetIDPhongByTenPhong(string name)
        {
            string s = "";
            foreach(var i in db.PHONGs.ToList())
            {
                if( i.TenPhong == name)
                {
                    s = i.IdPhong;
                }
            }
            return s;
        }

        // tu dong lay 1 IdChiTietBook
        public string GetNewIDCTB()
        {
            int idtt = 0;
            List<string> data = new List<string>();
            foreach (var i in db.ChiTietBooks.Select(p => p).OrderBy(p => p.IdChiTietBook))
            {
                idtt++;
            }
             idtt++;
            return "CTB" + idtt.ToString();
        }

        // Them vao Book( IdKhachHang, IdNhanVien, sotiendat )
        public void AddBook(string idkhach, string idNV, int tien)
        {
            Book s = new Book
            {
                IdBook = getNewIDBook(),
                IdKhachHang = idkhach,
                IdNhanVien = idNV,
                TrangThai = false,
                TienCoc = tien,
            };
            db.Books.Add(s);
            db.SaveChanges();
        }

        // Them Vao Book voi dieu kien da ton tai khach hang da thue phong truoc do
        public void AddBook2(string idkhach, string idNV, int tien)
        {
            Book s = new Book
            {
                IdBook = GetIdBookByIdKH(idkhach),
                IdKhachHang = idkhach,
                IdNhanVien = idNV,
                TrangThai = false,
                TienCoc = tien,
            };
            db.Books.Add(s);
            db.SaveChanges();
        }

        // them chi tiet book 
        public void AddChiTiet(List<ChiTietBook> data)
        {
            foreach (ChiTietBook i in data)
            {
                db.ChiTietBooks.Add(i);
            }
            db.SaveChanges();
        }
    }
}
