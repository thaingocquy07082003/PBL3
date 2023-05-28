using PBL3_BYME.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;

namespace PBL3_BYME.BLL
{
    public class QL_HoaDon
    {
        private QLKSEntities db = new QLKSEntities();
        private static QL_HoaDon _Instance;
        public static QL_HoaDon Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new QL_HoaDon();
                }
                return _Instance;
            }
            set { }
        }

        public DataTable getAllHoaDon()
        {
            var allData = from row in db.HoaDons
                          select new
                          {
                              row.IdHoaDon,
                              row.IdKhachHang,
                              row.IdNhanVien,
                              row.NgayHoaDon,
                              row.TinhTrang,
                              row.GhiChu,
                              row.TienTraTruoc
                          };

            var dataTable = new DataTable();

            dataTable.Columns.Add("IdHoaDon", typeof(string));
            dataTable.Columns.Add("IdKhachHang", typeof(string));
            dataTable.Columns.Add("IdNhanVien", typeof(string));
            dataTable.Columns.Add("NgayHoaDon", typeof(DateTime));
            dataTable.Columns.Add("TinhTrang", typeof(bool));
            dataTable.Columns.Add("GhiChu", typeof(string));
            dataTable.Columns.Add("TienTraTruoc", typeof(decimal));

            foreach (var item in allData)
            {
                var row = dataTable.NewRow();

                row["IdHoaDon"] = item.IdHoaDon;
                row["IdKhachHang"] = item.IdKhachHang;
                row["IdNhanVien"] = item.IdNhanVien;
                row["NgayHoaDon"] = item.NgayHoaDon;
                row["TinhTrang"] = item.TinhTrang;
                row["GhiChu"] = item.GhiChu;
                row["TienTraTruoc"] = item.TienTraTruoc;

                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
        // Lay tat ca khach hang trong csdl tra ve 1 list cac KhachHangView
        public DataTable getAllKhachHang()
        {
            var allData = from row in db.KhachHangs
                          select new
                          {
                              row.IdKhachHang,
                              row.Ten
                          };

            var dataTable = new DataTable();
            dataTable.Columns.Add("IdKhachHang", typeof(string));
            dataTable.Columns.Add("Ten", typeof(string));
            foreach (var item in allData)
            {
                var row = dataTable.NewRow();
                row["IdKhachHang"] = item.IdKhachHang;
                row["Ten"] = item.Ten;

                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        public DataTable getAllNhanVien()
        {
            var allData = from row in db.NhanViens
                          select new
                          {
                              row.IdNhanVien,
                              row.Ten
                          };

            var dataTable = new DataTable();
            dataTable.Columns.Add("IdNhanVien", typeof(string));
            dataTable.Columns.Add("Ten", typeof(string));
            foreach (var item in allData)
            {
                var row = dataTable.NewRow();
                row["IdNhanVien"] = item.IdNhanVien;
                row["Ten"] = item.Ten;

                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        public DataTable getAllPhong()
        {
            var allData = from row in db.PHONGs
                          select new
                          {
                              row.IdPhong,
                              row.TenPhong
                          };

            var dataTable = new DataTable();
            dataTable.Columns.Add("IdPhong", typeof(string));
            dataTable.Columns.Add("TenPhong", typeof(string));
            foreach (var item in allData)
            {
                var row = dataTable.NewRow();
                row["IdPhong"] = item.IdPhong;
                row["TenPhong"] = item.TenPhong;

                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        public DataTable getAllLoaiVatDung()
        {
            var allData = from row in db.LoaiVatDungs
                          select new
                          {
                              row.IdLoaiVatDung,
                              row.TenVatDung
                          };

            var dataTable = new DataTable();
            dataTable.Columns.Add("IdLoaiVatDung", typeof(string));
            dataTable.Columns.Add("TenVatDung", typeof(string));
            foreach (var item in allData)
            {
                var row = dataTable.NewRow();
                row["IdLoaiVatDung"] = item.IdLoaiVatDung;
                row["TenVatDung"] = item.TenVatDung;

                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        // Them Khach Hang
        public void ThemHoaDon(string idPhong, string idLoaiVatDung, int soluonglamhu, string idhoadon, string idkhachhang, string idnhanvien, DateTime ngayhoadon, bool tinhtrang, string ghichu, decimal tientratrc)
        {
            LamHu lh = new LamHu
            {
                IdHoaDon = idhoadon,
                IdPhong = idPhong,
                IdLoaiVatDung = idLoaiVatDung,
                SoLuongLamHu = soluonglamhu
            };

            db.LamHus.Add(lh);
            db.SaveChanges();

            HoaDon hd = new HoaDon
            {
                IdHoaDon = idhoadon,
                IdKhachHang = idkhachhang,
                IdNhanVien = idnhanvien,
                NgayHoaDon = ngayhoadon,
                TinhTrang = tinhtrang,
                GhiChu = ghichu,
                TienTraTruoc = tientratrc
            };
            db.HoaDons.Add(hd);
            db.SaveChanges();
        }

        public void Update(string idhoadon, string idkhachhang, string idnhanvien, DateTime ngayhoadon, bool tinhtrang, string ghichu, decimal tientratrc)
        {
            var record = db.HoaDons.FirstOrDefault(x => x.IdHoaDon == idhoadon);

            if (record != null)
            {
                record.IdKhachHang = idkhachhang;
                record.IdNhanVien = idnhanvien;
                record.NgayHoaDon = ngayhoadon;
                record.TinhTrang = tinhtrang;
                record.GhiChu = ghichu;
                record.TienTraTruoc = tientratrc;

                db.SaveChanges();
            }
            else
            {
                throw new Exception($"Không tìm thấy hóa đơn có id: {idhoadon}");
            }
        }
        ////xoa khach hang
        public void delete(string id)
        {
            var record2 = db.ChiTietSuDungDichVus.FirstOrDefault(x => x.ID_HoaDon == id);
            db.ChiTietSuDungDichVus.Remove(record2);
            db.SaveChanges();

            var record = db.HoaDons.FirstOrDefault(x => x.IdHoaDon == id);
            db.HoaDons.Remove(record);
            db.SaveChanges();

            var record1 = db.LamHus.FirstOrDefault(x => x.IdHoaDon == id);
            db.LamHus.Remove(record1);
            db.SaveChanges();   
        }

        // Lay Id Vat dung ten loai vat dung
        public string GetIDVatDung(string name)
        {
            string id = "";
            foreach(LoaiVatDung i in db.LoaiVatDungs.ToList())
            {
                if(i.TenVatDung == name)
                {
                    id = i.IdLoaiVatDung;
                }
            }
            return id;
        }

        // Lay Id Khach Hang
        public string GetIDKhachHang(string name)
        {
            string id = "";
            foreach (KhachHang i in db.KhachHangs.ToList())
            {
                if (i.Ten == name)
                {
                    id = i.IdKhachHang;
                }
            }
            return id;
        }

        // Lay Id Nhan Vien
        public string GetIDNhanVien(string name)
        {
            string id = "";
            foreach (NhanVien i in db.NhanViens.ToList())
            {
                if (i.Ten == name)
                {
                    id = i.IdNhanVien;
                }
            }
            return id;
        }
        // Lay Id Phong
        // Lay Id Nhan Vien
        public string GetIDPhong(string name)
        {
            string id = "";
            foreach (PHONG i in db.PHONGs.ToList())
            {
                if (i.TenPhong == name)
                {
                    id = i.IdPhong;
                }
            }
            return id;
        }


    }
}
