﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCF_Service
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QLBSEntities : DbContext
    {
        public QLBSEntities()
            : base("name=QLBSEntities")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public DbSet<ChuDe> ChuDes { get; set; }
        public DbSet<DatHang> DatHangs { get; set; }
        public DbSet<DatHangCT> DatHangCTs { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public DbSet<QuangCao> QuangCaos { get; set; }
        public DbSet<Sach> Saches { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<TacGia> TacGias { get; set; }
        public DbSet<ThamGia> ThamGias { get; set; }
        public DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public DbSet<PhieuNhapCT> PhieuNhapCTs { get; set; }
    }
}