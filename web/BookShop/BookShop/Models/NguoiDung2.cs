namespace BookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NguoiDung2
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung2()
        {
            DonHang = new HashSet<DonHang>();
        }

        [Key]
        [StringLength(10)]
        public string MaKH { get; set; }

        [StringLength(100)]
        public string HoTenKH { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [StringLength(20)]
        public string NgaySinh { get; set; }

        [StringLength(20)]
        public string GioiTinh { get; set; }

        [StringLength(20)]
        public string SoDienThoai { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string TenDangNhap { get; set; }

        [StringLength(20)]
        public string MatKhau { get; set; }

        public int? LoaiTK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHang { get; set; }
    }
}
