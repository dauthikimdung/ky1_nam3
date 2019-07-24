namespace BookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonHang")]
    public partial class ChiTietDonHang
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10, ErrorMessage = "Mã sản phẩm phải nhỏ hơn 10 ký tự")]
        [Required]
        public string MaSP { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10, ErrorMessage = "Mã đơn hàng phải nhỏ hơn 10 ký tự")]
        [Required]
        public string MaDH { get; set; }

        public int? SoLuong { get; set; }

        public double? DonGia { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
