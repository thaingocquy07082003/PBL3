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
    
    public partial class LamHus
    {
        public string IdHoaDon { get; set; }
        public string IdPhong { get; set; }
        public string IdLoaiVatDung { get; set; }
        public Nullable<int> SoLuongLamHu { get; set; }
    
        public virtual HoaDons HoaDons { get; set; }
        public virtual LoaiVatDungs LoaiVatDungs { get; set; }
        public virtual Phongs Phongs { get; set; }
    }
}
