using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
    public class Product
    {

        public Product()
        {

        }
        [Key]
        [StringLength(10, ErrorMessage = "Mã sản phẩm phải nhỏ hơn 10 ký tự")]
        [Required(ErrorMessage = "Bạn phải nhập mã sản phẩm")]
        [DisplayName("Mã sản phẩm")]
        public string MaSP { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm")]
        [DisplayName("Tên sản phẩm")]
        public string TenSP { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập giá sản phẩm")]
        [DisplayName("Giá gốc")]
        public double? GiaGoc { get; set; }
        [DisplayName("Giảm giá")]
        public double? GiamGia { get; set; }
        [DisplayName("Số lượng")]
        public int? SoLuong { get; set; }

        [StringLength(20, ErrorMessage = "Tên file quá dài")]
        [DisplayName("Ảnh bìa")]
        public string AnhBiaSP { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Bạn phải nhập tác giả")]
        [DisplayName("Tác giả")]
        public string TacGia { get; set; }

        [StringLength(10, ErrorMessage = "Mã chi tiết phải nhỏ hơn 10 ký tự")]
        [Required(ErrorMessage = "Bạn phải nhập mã chi tiết")]
        [DisplayName("Mã chi tiết")]
        public string MaTTCT { get; set; }
        [DisplayName("Mã lĩnh vực")]
        public string MaLinhVuc { get; set; }
        [DisplayName("Mã nhà xuất bản")]
        public string MaNXB { get; set; }
        [DisplayName("Trạng thái")]
        public int? Moi { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage = "Bạn phải nhập ngày xuất bản")]
        [DisplayName("Ngày xuất bản")]
        public string NgayXuatBan { get; set; }
        [DisplayName("Trọng lượng")]
        public int? TrongLuong { get; set; }

        [StringLength(20)]
        [DisplayName("Kích thước")]
        public string KichThuoc { get; set; }

        [StringLength(20)]
        [DisplayName("Loại bìa")]
        public string LoaiBia { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập số trang")]
        [DisplayName("Số trang")]
        public int? SoTrang { get; set; }
        [DisplayName("Mô tả chi tiết")]
        public string MoTaChiTiet { get; set; }
    }
}