namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
        }

        [Key]
        [StringLength(10)]
        public string MaSP { get; set; }

        [StringLength(200)]
        public string TenSP { get; set; }

        public double? GiaGoc { get; set; }

        public double? GiamGia { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(20)]
        public string AnhBiaSP { get; set; }

        [StringLength(100)]
        public string TacGia { get; set; }

        [StringLength(10)]
        public string MaTTCT { get; set; }

        [StringLength(10)]
        public string MaLinhVuc { get; set; }

        [StringLength(10)]
        public string MaNXB { get; set; }

        [StringLength(20)]
        public string NgayXuatBan { get; set; }

        public int? TrongLuong { get; set; }

        [StringLength(20)]
        public string KichThuoc { get; set; }

        [StringLength(20)]
        public string LoaiBia { get; set; }

        public int? SoTrang { get; set; }

        public string MoTaChiTiet { get; set; }

        public int? Moi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }

        public virtual LinhVuc LinhVuc { get; set; }

        public virtual NhaXuatBan NhaXuatBan { get; set; }

        public virtual ThongTinChiTiet ThongTinChiTiet { get; set; }
    }
}
