﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QLKSEntities : DbContext
    {
        public QLKSEntities()
            : base("name=QLKSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<ChiTietBook> ChiTietBooks { get; set; }
        public virtual DbSet<ChiTietSuDungDichVu> ChiTietSuDungDichVus { get; set; }
        public virtual DbSet<ChiTietThuePhong> ChiTietThuePhongs { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LamHu> LamHus { get; set; }
        public virtual DbSet<LichSuDangNhap> LichSuDangNhaps { get; set; }
        public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }
        public virtual DbSet<LoaiVatDung> LoaiVatDungs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PHONG> PHONGs { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<VatDungPhong> VatDungPhongs { get; set; }
    }
}
