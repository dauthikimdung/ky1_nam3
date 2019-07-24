namespace BookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaXuatBan")]
    public partial class NhaXuatBan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhaXuatBan()
        {
            SanPham = new HashSet<SanPham>();
        }

        [Key]
        [StringLength(10, ErrorMessage = "Mã nhà xuất bản phải nhỏ hơn 10 ký tự")]
        [Required(ErrorMessage = "Bạn phải nhập mã nhà xuất bản")]
        [DisplayName("Mã nhà xuất bản")]
        public string MaNXB { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Bạn phải nhập tên nhà xuất bản")]
        [DisplayName("Tên nhà xuất bản")]
        public string TenNXB { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Bạn phải nhập địa chỉ")]
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Bạn phải nhập số điện thoại")]
        [DisplayName("Số điện thoại")]
        public string SoDienThoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
