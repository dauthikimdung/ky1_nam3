namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        [StringLength(20)]
        public string TenDangNhap { get; set; }

        [Required]
        [StringLength(20)]
        public string MatKhau { get; set; }

        public int? LoaiTK { get; set; }

        [StringLength(10)]
        public string MaKH { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual TaiKhoan TaiKhoan1 { get; set; }

        public virtual TaiKhoan TaiKhoan2 { get; set; }
    }
}
