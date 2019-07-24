namespace BookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LinhVuc")]
    public partial class LinhVuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LinhVuc()
        {
            SanPham = new HashSet<SanPham>();
        }

        [Key]
        [StringLength(10, ErrorMessage = "Mã lĩnh vực phải nhỏ hơn 10 ký tự")]
        [Required(ErrorMessage = "Bạn phải nhập mã lĩnh vực")]
        [DisplayName("Mã lĩnh vực")]
        public string MaLinhVuc { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Bạn phải nhập tên lĩnh vực")]
        [DisplayName("Tên lĩnh vực")]
        public string TenLinhVuc { get; set; }

        [Column(TypeName = "date")]
        [Required]
        [DisplayName("Ngày chỉnh sửa")]
        public DateTime? NgaySua { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
