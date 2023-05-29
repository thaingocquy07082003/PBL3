using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_BYME.DTO
{
    public class BaoCao
    {
        public String IdBaoCao { get; set; }
        public String ThangNam { get; set; }
        public int SoLuotThuePhongBT { get; set; }
        public int SoLuotThuePhongVIP { get; set; }
        public int SoNgayThuePhong { get; set; }
        public int DoanhThuDV { get; set; }
        public int DoanhThuPhong { get; set; }
        public int TongDoanhThu { get; set; }
    }
}