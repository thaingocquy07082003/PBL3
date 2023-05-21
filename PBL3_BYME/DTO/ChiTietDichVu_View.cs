using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_BYME.DTO
{
    public  class ChiTietDichVu_View
    {
        public int ID_ChiTietSuDungDichVu { get; set; }
        public string ID_Phong { get; set; }
        public string ID_DichVu { get; set; }
        public string ID_HoaDon { get; set; }
        public Nullable<System.DateTime> NgaySuDung { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<bool> TrangThai { get; set; }
    }
}
