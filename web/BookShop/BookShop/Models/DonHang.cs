namespace BookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
        }

        [Key]
        [StringLength(10)]
        public string MaDH { get; set; }

        [StringLength(100)]
        public string TenDH { get; set; }

        public int? TinhTrangGH { get; set; }

        public int? TinhTrangTT { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDat { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayGiao { get; set; }

        public double? TongTien { get; set; }

        [StringLength(10)]
        public string MaKH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }
    }
}
