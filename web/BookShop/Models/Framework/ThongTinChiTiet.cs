namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinChiTiet")]
    public partial class ThongTinChiTiet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThongTinChiTiet()
        {
            SanPham = new HashSet<SanPham>();
        }

        [Key]
        [StringLength(10)]
        public string MaTTCT { get; set; }

        [StringLength(20)]
        public string NgayXuatBan { get; set; }

        public int? TrongLuong { get; set; }

        [StringLength(20)]
        public string KichThuoc { get; set; }

        [StringLength(20)]
        public string LoaiBia { get; set; }

        public int? SoTrang { get; set; }

        public string MoTaChiTiet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
