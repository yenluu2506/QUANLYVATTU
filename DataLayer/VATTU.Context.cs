﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tb_CHUNGTU_CT> tb_CHUNGTU_CT { get; set; }
        public virtual DbSet<tb_CONGTY> tb_CONGTY { get; set; }
        public virtual DbSet<tb_DVT> tb_DVT { get; set; }
        public virtual DbSet<tb_SYS_FUNC> tb_SYS_FUNC { get; set; }
        public virtual DbSet<tb_SYS_GROUP> tb_SYS_GROUP { get; set; }
        public virtual DbSet<tb_SYS_REPORT> tb_SYS_REPORT { get; set; }
        public virtual DbSet<tb_SYS_RIGHT> tb_SYS_RIGHT { get; set; }
        public virtual DbSet<tb_SYS_RIGHT_REP> tb_SYS_RIGHT_REP { get; set; }
        public virtual DbSet<tb_SYS_USER> tb_SYS_USER { get; set; }
        public virtual DbSet<tb_TONKHO> tb_TONKHO { get; set; }
        public virtual DbSet<tb_XUATXU> tb_XUATXU { get; set; }
        public virtual DbSet<V_FUNC_SYS_RIGHT> V_FUNC_SYS_RIGHT { get; set; }
        public virtual DbSet<V_REP_SYS_RIGHT_REP> V_REP_SYS_RIGHT_REP { get; set; }
        public virtual DbSet<V_USER_IN_GROUP> V_USER_IN_GROUP { get; set; }
        public virtual DbSet<V_USER_NOTIN_GROUP> V_USER_NOTIN_GROUP { get; set; }
        public virtual DbSet<tb_DONVI> tb_DONVI { get; set; }
        public virtual DbSet<tb_NHOMHH> tb_NHOMHH { get; set; }
        public virtual DbSet<tb_SYS_SEQUENCE> tb_SYS_SEQUENCE { get; set; }
        public virtual DbSet<tb_CHUNGTU> tb_CHUNGTU { get; set; }
        public virtual DbSet<tb_HANGHOA> tb_HANGHOA { get; set; }
        public virtual DbSet<tb_NHACUNGCAP> tb_NHACUNGCAP { get; set; }
    }
}
