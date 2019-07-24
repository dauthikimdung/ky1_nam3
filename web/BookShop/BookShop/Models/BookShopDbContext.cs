namespace BookShop.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookShopDbContext : DbContext
    {
        public BookShopDbContext()
            : base("name=BookShopDbContext5")
        {
        }

        public virtual DbSet<ChiTietDonHang> ChiTietDonHang { get; set; }
        public virtual DbSet<DonHang> DonHang { get; set; }
        public virtual DbSet<LinhVuc> LinhVuc { get; set; }
        public virtual DbSet<NguoiDung> NguoiDung { get; set; }
        public virtual DbSet<NguoiDung2> NguoiDung2 { get; set; }
        public virtual DbSet<NhaXuatBan> NhaXuatBan { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }
        public virtual DbSet<ThongTinChiTiet> ThongTinChiTiet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.MaSP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.MaDH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.MaDH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.MaKH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.ChiTietDonHang)
                .WithRequired(e => e.DonHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LinhVuc>()
                .Property(e => e.MaLinhVuc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.MaKH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.SoDienThoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung2>()
                .Property(e => e.MaKH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung2>()
                .Property(e => e.NgaySinh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung2>()
                .Property(e => e.SoDienThoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung2>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung2>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung2>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NhaXuatBan>()
                .Property(e => e.MaNXB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhaXuatBan>()
                .Property(e => e.SoDienThoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaSP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.AnhBiaSP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaTTCT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaLinhVuc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaNXB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietDonHang)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThongTinChiTiet>()
                .Property(e => e.MaTTCT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinChiTiet>()
                .Property(e => e.NgayXuatBan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinChiTiet>()
                .Property(e => e.KichThuoc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ThongTinChiTiet>()
                .HasMany(e => e.SanPham)
                .WithOptional(e => e.ThongTinChiTiet)
                .HasForeignKey(e => e.MaTTCT);

            modelBuilder.Entity<ThongTinChiTiet>()
                .HasMany(e => e.SanPham1)
                .WithOptional(e => e.ThongTinChiTiet1)
                .HasForeignKey(e => e.MaTTCT);
        }
    }
}
