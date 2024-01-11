using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BTLWEBNC_WEBNOITHAT.Models;

public partial class QlbanNoiThatContext : DbContext
{
    public QlbanNoiThatContext()
    {
    }

    public QlbanNoiThatContext(DbContextOptions<QlbanNoiThatContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TAnhChiTietSp> TAnhChiTietSps { get; set; }

    public virtual DbSet<TAnhSp> TAnhSps { get; set; }

    public virtual DbSet<TBlog> TBlogs { get; set; }

    public virtual DbSet<TBlogTag> TBlogTags { get; set; }

    public virtual DbSet<TChiTietHdb> TChiTietHdbs { get; set; }

    public virtual DbSet<TChiTietSanPham> TChiTietSanPhams { get; set; }

    public virtual DbSet<TDanhMucSp> TDanhMucSps { get; set; }

    public virtual DbSet<THoaDonBan> THoaDonBans { get; set; }

    public virtual DbSet<TKhachHang> TKhachHangs { get; set; }

    public virtual DbSet<TKichThuoc> TKichThuocs { get; set; }

    public virtual DbSet<TLoaiSp> TLoaiSps { get; set; }

    public virtual DbSet<TMauSac> TMauSacs { get; set; }

    public virtual DbSet<TNhanVien> TNhanViens { get; set; }

    public virtual DbSet<TUser> TUsers { get; set; }

    public virtual DbSet<TblChiTietGioHang1> TblChiTietGioHang1s { get; set; }

    public virtual DbSet<TblCtyeuThich> TblCtyeuThiches { get; set; }

    public virtual DbSet<TblGioHang> TblGioHangs { get; set; }

    public virtual DbSet<TblYeuThich> TblYeuThiches { get; set; }

    public virtual DbSet<Tbldisabled> Tbldisableds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-44BQKJA;Initial Catalog=QLBanNoiThat;Integrated Security=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TAnhChiTietSp>(entity =>
        {
            entity.HasKey(e => new { e.MaChiTietSp, e.TenFileAnh });

            entity.ToTable("tAnhChiTietSP");

            entity.Property(e => e.MaChiTietSp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaChiTietSP");
            entity.Property(e => e.TenFileAnh)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.MaChiTietSpNavigation).WithMany(p => p.TAnhChiTietSps)
                .HasForeignKey(d => d.MaChiTietSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tAnhChiTietSP_tChiTietSanPham");
        });

        modelBuilder.Entity<TAnhSp>(entity =>
        {
            entity.HasKey(e => new { e.MaSp, e.TenFileAnh });

            entity.ToTable("tAnhSP");

            entity.Property(e => e.MaSp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaSP");
            entity.Property(e => e.TenFileAnh)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.TAnhSps)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tAnhSP_tDanhMucSP");
        });

        modelBuilder.Entity<TBlog>(entity =>
        {
            entity.HasKey(e => e.Idblog);

            entity.ToTable("tBlog");

            entity.Property(e => e.Idblog).HasColumnName("IDBlog");
            entity.Property(e => e.Idtag).HasColumnName("IDTag");
            entity.Property(e => e.NgayDang).HasColumnType("datetime");
            entity.Property(e => e.Scontent)
                .HasMaxLength(500)
                .HasColumnName("SContent");
            entity.Property(e => e.TacGia).HasMaxLength(100);
            entity.Property(e => e.TieuDe).HasMaxLength(200);

            entity.HasOne(d => d.IdtagNavigation).WithMany(p => p.TBlogs)
                .HasForeignKey(d => d.Idtag)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_tBlog_tBlogTag");
        });

        modelBuilder.Entity<TBlogTag>(entity =>
        {
            entity.HasKey(e => e.Idtag);

            entity.ToTable("tBlogTag");

            entity.Property(e => e.Idtag).HasColumnName("IDTag");
            entity.Property(e => e.Tag).HasMaxLength(200);
        });

        modelBuilder.Entity<TChiTietHdb>(entity =>
        {
            entity.HasKey(e => new { e.MaHoaDon, e.MaChiTietSp });

            entity.ToTable("tChiTietHDB");

            entity.Property(e => e.MaHoaDon)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaChiTietSp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaChiTietSP");
            entity.Property(e => e.DonGiaBan).HasColumnType("money");
            entity.Property(e => e.GhiChu).HasMaxLength(100);

            entity.HasOne(d => d.MaChiTietSpNavigation).WithMany(p => p.TChiTietHdbs)
                .HasForeignKey(d => d.MaChiTietSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tChiTietHDB_tChiTietSanPham");

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.TChiTietHdbs)
                .HasForeignKey(d => d.MaHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tChiTietHDB_tHoaDonBan");
        });

        modelBuilder.Entity<TChiTietSanPham>(entity =>
        {
            entity.HasKey(e => e.MaChiTietSp);

            entity.ToTable("tChiTietSanPham");

            entity.Property(e => e.MaChiTietSp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaChiTietSP");
            entity.Property(e => e.AnhDaiDien)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaKichThuoc)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaMauSac)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaSp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaSP");
            entity.Property(e => e.Slton).HasColumnName("SLTon");
            entity.Property(e => e.Video)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.MaKichThuocNavigation).WithMany(p => p.TChiTietSanPhams)
                .HasForeignKey(d => d.MaKichThuoc)
                .HasConstraintName("FK_tChiTietSanPham_tKichThuoc");

            entity.HasOne(d => d.MaMauSacNavigation).WithMany(p => p.TChiTietSanPhams)
                .HasForeignKey(d => d.MaMauSac)
                .HasConstraintName("FK_tChiTietSanPham_tMauSac");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.TChiTietSanPhams)
                .HasForeignKey(d => d.MaSp)
                .HasConstraintName("FK_tChiTietSanPham_tDanhMucSP");
        });

        modelBuilder.Entity<TDanhMucSp>(entity =>
        {
            entity.HasKey(e => e.MaSp);

            entity.ToTable("tDanhMucSP");

            entity.Property(e => e.MaSp)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaSP");
            entity.Property(e => e.AnhDaiDien)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GiaLonNhat).HasColumnType("money");
            entity.Property(e => e.GiaNhoNhat).HasColumnType("money");
            entity.Property(e => e.GioiThieuSp)
                .HasMaxLength(255)
                .HasColumnName("GioiThieuSP");
            entity.Property(e => e.MaDt)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaDT");
            entity.Property(e => e.MaLoai)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenSp)
                .HasMaxLength(150)
                .HasColumnName("TenSP");

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.TDanhMucSps)
                .HasForeignKey(d => d.MaLoai)
                .HasConstraintName("FK_tDanhMucSP_tLoaiSP");
        });

        modelBuilder.Entity<THoaDonBan>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon);

            entity.ToTable("tHoaDonBan");

            entity.Property(e => e.MaHoaDon)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GhiChu).HasMaxLength(100);
            entity.Property(e => e.GiamGiaHd).HasColumnName("GiamGiaHD");
            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NgayHoaDon).HasColumnType("datetime");
            entity.Property(e => e.TongTienHd)
                .HasColumnType("money")
                .HasColumnName("TongTienHD");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.THoaDonBans)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK_tHoaDonBan_tKhachHang");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.THoaDonBans)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK_tHoaDonBan_tNhanVien");
        });

        modelBuilder.Entity<TKhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhanhHang);

            entity.ToTable("tKhachHang");

            entity.Property(e => e.MaKhanhHang)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AnhDaiDien)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DiaChi).HasMaxLength(150);
            entity.Property(e => e.GhiChu).HasMaxLength(100);
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenKhachHang).HasMaxLength(100);
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("username");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.TKhachHangs)
                .HasForeignKey(d => d.Username)
                .HasConstraintName("FK_tKhachHang_tUser");
        });

        modelBuilder.Entity<TKichThuoc>(entity =>
        {
            entity.HasKey(e => e.MaKichThuoc);

            entity.ToTable("tKichThuoc");

            entity.Property(e => e.MaKichThuoc)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.KichThuoc)
                .HasMaxLength(150)
                .IsFixedLength();
        });

        modelBuilder.Entity<TLoaiSp>(entity =>
        {
            entity.HasKey(e => e.MaLoai);

            entity.ToTable("tLoaiSP");

            entity.Property(e => e.MaLoai)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Loai).HasMaxLength(100);
        });

        modelBuilder.Entity<TMauSac>(entity =>
        {
            entity.HasKey(e => e.MaMauSac);

            entity.ToTable("tMauSac");

            entity.Property(e => e.MaMauSac)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenMauSac).HasMaxLength(100);
        });

        modelBuilder.Entity<TNhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien);

            entity.ToTable("tNhanVien");

            entity.Property(e => e.MaNhanVien)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AnhDaiDien)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ChucVu).HasMaxLength(100);
            entity.Property(e => e.DiaChi).HasMaxLength(150);
            entity.Property(e => e.GhiChu).HasMaxLength(100);
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.SoDienThoai1)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SoDienThoai2)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TenNhanVien).HasMaxLength(100);
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("username");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.TNhanViens)
                .HasForeignKey(d => d.Username)
                .HasConstraintName("FK_tNhanVien_tUser");
        });

        modelBuilder.Entity<TUser>(entity =>
        {
            entity.HasKey(e => e.Username);

            entity.ToTable("tUser");

            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("username");
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("password");
        });

        modelBuilder.Entity<TblChiTietGioHang1>(entity =>
        {
            entity.HasKey(e => e.IdchiTietDonHang);

            entity.ToTable("TblChiTietGioHang1");

            entity.Property(e => e.IdchiTietDonHang)
                .ValueGeneratedNever()
                .HasColumnName("IDChiTietDonHang");
            entity.Property(e => e.HinhAnh)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.IdchiTietSanPham)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IDChiTietSanPham");
            entity.Property(e => e.IddonHang).HasColumnName("IDDonHang");
            entity.Property(e => e.TenSp)
                .HasMaxLength(150)
                .HasColumnName("TenSP");
            

            entity.HasOne(d => d.IdchiTietSanPhamNavigation).WithMany(p => p.TblChiTietGioHang1s)
                .HasForeignKey(d => d.IdchiTietSanPham)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TblChiTietGioHang1_tChiTietSanPham");

            entity.HasOne(d => d.IddonHangNavigation).WithMany(p => p.TblChiTietGioHang1s)
                .HasForeignKey(d => d.IddonHang)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_TblChiTietGioHang1_Tbl_GioHang");
        });

        modelBuilder.Entity<TblCtyeuThich>(entity =>
        {
            entity.HasKey(e => e.IdctyeuThich).HasName("IDCTYeuThich");

            entity.ToTable("TblCTYeuThich");

            entity.Property(e => e.IdctyeuThich)
                .ValueGeneratedNever()
                .HasColumnName("IDCTYeuThich");
            entity.Property(e => e.HinhAnh)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.IdchiTietSanPham)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IDChiTietSanPham");
            entity.Property(e => e.IdyeuThich).HasColumnName("IDYeuThich");
            entity.Property(e => e.TenSp)
                .HasMaxLength(150)
                .HasColumnName("TenSP");

            entity.HasOne(d => d.IdchiTietSanPhamNavigation).WithMany(p => p.TblCtyeuThiches)
                .HasForeignKey(d => d.IdchiTietSanPham)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TblCTYeuThich_tChiTietSanPham");

            entity.HasOne(d => d.IdyeuThichNavigation).WithMany(p => p.TblCtyeuThiches)
                .HasForeignKey(d => d.IdyeuThich)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("[FK_TblCTYeuThich_TblYeuThich");
        });

        modelBuilder.Entity<TblGioHang>(entity =>
        {
            entity.HasKey(e => e.IdgioHang);

            entity.ToTable("Tbl_GioHang");

            entity.Property(e => e.IdgioHang)
                .ValueGeneratedNever()
                .HasColumnName("IDGioHang");
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.IdkhachHang)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IDKhachHang");
            entity.Property(e => e.ModyfiAt).HasColumnType("datetime");
            entity.Property(e => e.TenGioHang).HasMaxLength(100);

            entity.HasOne(d => d.IdkhachHangNavigation).WithMany(p => p.TblGioHangs)
                .HasForeignKey(d => d.IdkhachHang)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Tbl_GioHang_tKhachHang");
        });

        modelBuilder.Entity<TblYeuThich>(entity =>
        {
            entity.HasKey(e => e.IdyeuThich);

            entity.ToTable("TblYeuThich");

            entity.Property(e => e.IdyeuThich)
                .ValueGeneratedNever()
                .HasColumnName("IDYeuThich");
            entity.Property(e => e.IdkhachHang)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IDKhachHang");

            entity.HasOne(d => d.IdkhachHangNavigation).WithMany(p => p.TblYeuThiches)
                .HasForeignKey(d => d.IdkhachHang)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_TblYeuThich_tKhachHang");
        });

        modelBuilder.Entity<Tbldisabled>(entity =>
        {
            entity.HasKey(e => e.FkT2);

            entity.ToTable("tbldisabled");

            entity.Property(e => e.FkT2)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("FK_T2");
            entity.Property(e => e.Disabled).HasColumnName("disabled");
            entity.Property(e => e.Longtime)
                .HasColumnType("datetime")
                .HasColumnName("longtime");

            entity.HasOne(d => d.FkT2Navigation).WithOne(p => p.Tbldisabled)
                .HasForeignKey<Tbldisabled>(d => d.FkT2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbldisabled_tDanhMucSP");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
