using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebQLLuongNV.Models;

public partial class QlnvpartTimeContext : DbContext
{
    public QlnvpartTimeContext()
    {
    }

    public QlnvpartTimeContext(DbContextOptions<QlnvpartTimeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BangLuongNv> BangLuongNvs { get; set; }

    public virtual DbSet<CalamViec> CalamViecs { get; set; }

    public virtual DbSet<ChiTietCaLamViec> ChiTietCaLamViecs { get; set; }

    public virtual DbSet<ChiTietLichLam> ChiTietLichLams { get; set; }

    public virtual DbSet<DangKy> DangKies { get; set; }

    public virtual DbSet<LichLam> LichLams { get; set; }

    public virtual DbSet<LoaiCongViec> LoaiCongViecs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<TongLuongAllnv> TongLuongAllnvs { get; set; }

    public virtual DbSet<VaiTro> VaiTros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("workstation id=qlynvPT.mssql.somee.com;packet size=4096;user id=phamphuckha12321_SQLLogin_2;pwd=6euss5x12j;data source=qlynvPT.mssql.somee.com;persist security info=False;initial catalog=qlynvPT;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BangLuongNv>(entity =>
        {
            entity.HasKey(e => e.MaLuong).HasName("PK__BangLuon__6609A48D7B920F62");

            entity.ToTable("BangLuongNV");

            entity.Property(e => e.MaLichLam)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaQuanLy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ThangNam).HasColumnType("date");
            entity.Property(e => e.TongLuong).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.MaLichLamNavigation).WithMany(p => p.BangLuongNvs)
                .HasForeignKey(d => d.MaLichLam)
                .HasConstraintName("FK_BangLuongNV_LichLam");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.BangLuongNvs)
                .HasForeignKey(d => d.MaNhanVien)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__BangLuong__MaNha__59FA5E80");
        });

        modelBuilder.Entity<CalamViec>(entity =>
        {
            entity.HasKey(e => e.IdcalamViec).HasName("PK__CalamVie__CD76E12AB99D378A");

            entity.ToTable("CalamViec");

            entity.Property(e => e.IdcalamViec).HasColumnName("IDCalamViec");
            entity.Property(e => e.Mucluong)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("mucluong");
            entity.Property(e => e.TenCa).HasMaxLength(100);
        });

        modelBuilder.Entity<ChiTietCaLamViec>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ChiTietC__3214EC076EB8E553");

            entity.ToTable("ChiTietCaLamViec");

            entity.Property(e => e.IdcaLamViec).HasColumnName("IDCaLamViec");

            entity.HasOne(d => d.IdChiTietLichLamNavigation).WithMany(p => p.ChiTietCaLamViecs)
                .HasForeignKey(d => d.IdChiTietLichLam)
                .HasConstraintName("FK__ChiTietCa__IdChi__29221CFB");

            entity.HasOne(d => d.IdcaLamViecNavigation).WithMany(p => p.ChiTietCaLamViecs)
                .HasForeignKey(d => d.IdcaLamViec)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietCa__IDCaL__2A164134");
        });

        modelBuilder.Entity<ChiTietLichLam>(entity =>
        {
            entity.HasKey(e => e.IdChitietLichLam).HasName("PK__ChiTietL__C96CD8A8D5A0C0E1");

            entity.ToTable("ChiTietLichLam");

            entity.Property(e => e.GioBd).HasColumnName("GioBD");
            entity.Property(e => e.GioKt).HasColumnName("GioKT");
            entity.Property(e => e.LuongLoaiCv)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("LuongLoaiCV");
            entity.Property(e => e.MaLichLam)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaLoaiCongViec)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NoiLam).HasMaxLength(100);
            entity.Property(e => e.SoCaCvk).HasColumnName("SoCaCVK");
            entity.Property(e => e.SonguoilamCvk).HasColumnName("SonguoilamCVk");

            entity.HasOne(d => d.MaLichLamNavigation).WithMany(p => p.ChiTietLichLams)
                .HasForeignKey(d => d.MaLichLam)
                .HasConstraintName("FK__ChiTietLi__MaLic__05D8E0BE");

            entity.HasOne(d => d.MaLoaiCongViecNavigation).WithMany(p => p.ChiTietLichLams)
                .HasForeignKey(d => d.MaLoaiCongViec)
                .HasConstraintName("FK_ChiTietLichLam_LoaiCongViec");
        });

        modelBuilder.Entity<DangKy>(entity =>
        {
            entity.HasKey(e => e.IdDangKy).HasName("PK__DangKy__FED6204A17381F73");

            entity.ToTable("DangKy");

            entity.Property(e => e.IdchitietLichLam).HasColumnName("IDChitietLichLam");
            entity.Property(e => e.LoaiDangKy).HasMaxLength(10);
            entity.Property(e => e.MaLichLam)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ThoiGianDky)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ThoiGianDKY");
            entity.Property(e => e.TrangThaiNhomCa).HasMaxLength(10);

            entity.HasOne(d => d.IdchitietLichLamNavigation).WithMany(p => p.DangKies)
                .HasForeignKey(d => d.IdchitietLichLam)
                .HasConstraintName("FK_DangKy_ChiTietLichLam");

            entity.HasOne(d => d.MaLichLamNavigation).WithMany(p => p.DangKies)
                .HasForeignKey(d => d.MaLichLam)
                .HasConstraintName("FK__DangKy__MaLichLa__5629CD9C");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.DangKies)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__DangKy__MaNhanVi__571DF1D5");
        });

        modelBuilder.Entity<LichLam>(entity =>
        {
            entity.HasKey(e => e.MaLichLam).HasName("PK__LichLam__0A7F064A8D9ED799");

            entity.ToTable("LichLam");

            entity.Property(e => e.MaLichLam)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaQuanLy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ThuNgayThangNam).HasColumnType("date");

            entity.HasOne(d => d.MaQuanLyNavigation).WithMany(p => p.LichLams)
                .HasForeignKey(d => d.MaQuanLy)
                .HasConstraintName("FK__LichLam__MaQuanL__4BAC3F29");
        });

        modelBuilder.Entity<LoaiCongViec>(entity =>
        {
            entity.HasKey(e => e.MaLoaiCongViec).HasName("PK__LoaiCong__D119044C89DD5F08");

            entity.ToTable("LoaiCongViec");

            entity.Property(e => e.MaLoaiCongViec)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TenLoaiCongViec).HasMaxLength(50);
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA47B3F5BFBB");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Cmnd)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("CMND");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MaTaiKhoan)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.TenNhanVien).HasMaxLength(100);

            entity.HasOne(d => d.MaTaiKhoanNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaTaiKhoan)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__NhanVien__MaTaiK__46E78A0C");
        });

        modelBuilder.Entity<PhanQuyen>(entity =>
        {
            entity.HasKey(e => e.MaQuyen).HasName("PK__PhanQuye__1D4B7ED41B1B3FA5");

            entity.ToTable("PhanQuyen");

            entity.HasIndex(e => e.TenQuyen, "UQ__PhanQuye__5637EE7975F67A45").IsUnique();

            entity.Property(e => e.TenQuyen)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.MaTaiKhoan).HasName("PK__TaiKhoan__AD7C6529A731C6D9");

            entity.ToTable("TaiKhoan");

            entity.HasIndex(e => e.TenTaiKhoan, "UQ__TaiKhoan__B106EAF831AA2447").IsUnique();

            entity.Property(e => e.MaTaiKhoan)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MatKhau)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TenTaiKhoan)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValueSql("('Active')");

            entity.HasOne(d => d.MaVaiTroNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.MaVaiTro)
                .HasConstraintName("FK_TaiKhoan_VaiTro");
        });

        modelBuilder.Entity<TongLuongAllnv>(entity =>
        {
            entity.HasKey(e => e.ThangID).HasName("PK__TongLuon__D122B1991FA36065");

            entity.ToTable("TongLuongALLNV");

            entity.Property(e => e.ThangID)
                .HasColumnType("date")
                .HasColumnName("Thang_iD");
            entity.Property(e => e.MaLuong).ValueGeneratedOnAdd();
            entity.Property(e => e.MaQuanLy)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TongLuongAllNv1)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("TongLuongAllNV");

            entity.HasOne(d => d.MaLuongNavigation).WithMany(p => p.TongLuongAllnvs)
                .HasForeignKey(d => d.MaLuong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TongLuongALLNV_BangLuongNV");

            entity.HasOne(d => d.MaQuanLyNavigation).WithMany(p => p.TongLuongAllnvs)
                .HasForeignKey(d => d.MaQuanLy)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_TongLuongALLNV_NhanVien");
        });

        modelBuilder.Entity<VaiTro>(entity =>
        {
            entity.HasKey(e => e.MaVaiTro).HasName("PK__VaiTro__C24C41CF4D1B41C0");

            entity.ToTable("VaiTro");

            entity.HasIndex(e => e.TenVaiTro, "UQ__VaiTro__1DA55814EC57616D").IsUnique();

            entity.Property(e => e.TenVaiTro)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasMany(d => d.MaQuyens).WithMany(p => p.MaVaiTros)
                .UsingEntity<Dictionary<string, object>>(
                    "VaiTroPhanQuyen",
                    r => r.HasOne<PhanQuyen>().WithMany()
                        .HasForeignKey("MaQuyen")
                        .HasConstraintName("FK__VaiTro_Ph__MaQuy__3E52440B"),
                    l => l.HasOne<VaiTro>().WithMany()
                        .HasForeignKey("MaVaiTro")
                        .HasConstraintName("FK__VaiTro_Ph__MaVai__3D5E1FD2"),
                    j =>
                    {
                        j.HasKey("MaVaiTro", "MaQuyen").HasName("PK__VaiTro_P__9398F622688720E1");
                        j.ToTable("VaiTro_PhanQuyen");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
