//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PBL3_BYME
{
    using System;
    using System.Collections.Generic;
    
    public partial class LichSuDangNhap
    {
        public string IdLichSu { get; set; }
        public string IdNhanVien { get; set; }
        public Nullable<System.DateTime> ThoiGian { get; set; }
        public Nullable<bool> TrangThai { get; set; }
    
        public virtual NhanVien NhanVien { get; set; }
    }
}