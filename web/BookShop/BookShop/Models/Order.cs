using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
    public class Order
    {
        public Order()
        { }
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

        public string MaSP { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10, ErrorMessage = "Mã đơn hàng phải nhỏ hơn 10 ký tự")]
        [Required]
        public string MaDH { get; set; }

        public int? SoLuong { get; set; }

        public double? DonGia { get; set; }
    }
}