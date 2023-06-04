using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3_BYME.DTO;
namespace PBL3_BYME.BLL
{
    public class QL_Phong
    {
        private QLKSEntities db = new QLKSEntities();
        private static QL_Phong _Instance;
        public static QL_Phong Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new QL_Phong();
                }
                return _Instance;
            }
            set { }
        }

        public DataTable getAllPhong()
        {
            var allData = from row in db.PHONGs
                          select new
                          {
                              row.IdPhong,
                              row.TenPhong,
                              row.DonGiaPhong,
                              row.TrangThai,
                          };

            var dataTable = new DataTable();

            dataTable.Columns.Add("IdPhong", typeof(string));
            dataTable.Columns.Add("TenPhong", typeof(string));
            dataTable.Columns.Add("DonGiaPhong", typeof(decimal));
            dataTable.Columns.Add("TrangThai", typeof(bool));

            foreach (var item in allData)
            {
                var row = dataTable.NewRow();

                row["IdPhong"] = item.IdPhong;
                row["TenPhong"] = item.TenPhong;
                row["DonGiaPhong"] = item.DonGiaPhong;
                row["TrangThai"] = item.TrangThai;

                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
        // Lay tat ca khach hang trong csdl tra ve 1 list cac KhachHangView
        public DataTable getAllLoaiPhong()
        {
            var allData = from row in db.LoaiPhongs
                          select new
                          {
                              row.IdLoaiPhong,
                              row.TenLoaiPhong
                          };

            var dataTable = new DataTable();
            dataTable.Columns.Add("IdLoaiPhong", typeof(string));
            dataTable.Columns.Add("TenLoaiPhong", typeof(string));
            foreach (var item in allData)
            {
                var row = dataTable.NewRow();
                row["IdLoaiPhong"] = item.IdLoaiPhong;
                row["TenLoaiPhong"] = item.TenLoaiPhong;

                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        public void Them(string idloaiphong, string idphong, string tenphong, int dongia, bool trangthai)
        {
            PHONG phong = new PHONG
            {
                IdLoaiPhong = idloaiphong,
                IdPhong = idphong,
                TenPhong = tenphong,
                DonGiaPhong = dongia,
                TrangThai = trangthai
            };
            db.PHONGs.Add(phong);
            db.SaveChanges();
        }

        public void Update(string idPhong, string tenPhong, int gia, bool trangthai)
        {
            var record = db.PHONGs.FirstOrDefault(x => x.IdPhong == idPhong);

            if (record != null)
            {
                record.TenPhong = tenPhong;
                record.DonGiaPhong = gia;
                record.TrangThai = trangthai;

                db.SaveChanges();
            }
            else
            {
                throw new Exception($"Không tìm thấy phòng có id: {idPhong}");
            }
        }

        public List<Phong_View> GetPhongView()
        {
            List<Phong_View> data = new List<Phong_View>();
            foreach(PHONG i in db.PHONGs.ToList())
            {
                foreach(LoaiPhong j in db.LoaiPhongs.ToList())
                {
                    if(i.IdLoaiPhong == j.IdLoaiPhong)
                    {
                        data.Add(new Phong_View
                        {
                            IdPhong = i.IdPhong,
                            NamePhong = i.TenPhong,
                            LoaiPhong = j.TenLoaiPhong,
                            TrangThai = Convert.ToBoolean(i.TrangThai),
                            GiaTien = Convert.ToString(i.DonGiaPhong)
                        });
                    }
                }
            }
            return data;
        }
        public List<VatDungPhong_View> GetVatDungPhongByID(String id)
        {
            List<VatDungPhong_View> data= new List<VatDungPhong_View>();

            foreach (var i in db.VatDungPhongs.ToList())
            {
                if (i.IdPhong==id)
                {
                    data.Add(new VatDungPhong_View
                    {
                        IdVatDung = i.IdVatDung,
                        TenVatDung=GetTenVatDung(i.IdLoaiVatDung),
                        SoLuongVatDung=i.SoLuongBanDau.Value

                    });
                }
            }
            return data;
        }
        public String GetTenVatDung(String id) {
            String t="";
            foreach (var i in db.LoaiVatDungs.ToList())
            {
                if (i.IdLoaiVatDung==id)
                {
                    t=i.TenVatDung;
                }
            }
            return t;
        }
    }
}
