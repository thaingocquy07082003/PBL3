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
    
    public partial class DichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DichVu()
        {
            this.ChiTietSuDungDichVus = new HashSet<ChiTietSuDungDichVu>();
        }
    
        public string IdDichVu { get; set; }
        public string TenDichVu { get; set; }
        public string DonGia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietSuDungDichVu> ChiTietSuDungDichVus { get; set; }
    }
}