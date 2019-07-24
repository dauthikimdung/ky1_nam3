namespace BookShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [Key]
        [StringLength(10, ErrorMessage = "Mã khách hàng phải nhỏ hơn 10 ký tự")]
        [Required(ErrorMessage = "Bạn phải nhập mã khách hàng")]
        [DisplayName("Mã khách hàng")]
        public string MaKH { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Bạn phải nhập tên khách hàng")]
        [DisplayName("Tên khách hàng")]
        public string HoTenKH { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Bạn phải nhập địa chỉ")]
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }

        [Column(TypeName = "date")]
        [Required(ErrorMessage = "Bạn phải nhập ngày sinh")]
        [DisplayName("Ngày sinh")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(20)]
        [DisplayName("Giới tính")]
        public string GioiTinh { get; set; }

        [StringLength(20, ErrorMessage = "Chiều dài không hợp lệ")]
        [Required(ErrorMessage = "Bạn phải nhập số điện thoại")]
        [DisplayName("Số điện thoại")]
        public string SoDienThoai { get; set; }

        [StringLength(50)]
        [DisplayName("Email")]
        public string Email { get; set; }

        [StringLength(20, ErrorMessage = "Tên đăng nhập nhỏ hơn 20 ký tự")]
        [Required(ErrorMessage = "Bạn phải nhập tên đăng nhập")]
        [DisplayName("Tên đăng nhập")]
        public string TenDangNhap { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        [DisplayName("Mật khẩu")]
        public string MatKhau { get; set; }
        [Required]
        [DisplayName("Loại tài khoản")]
        public int? LoaiTK { get; set; }
    }
}
