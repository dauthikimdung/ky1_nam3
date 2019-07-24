namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public long ID { get; set; }
        [Required(ErrorMessage = "bạn phải nhập ngày đặt hàng")]
        public DateTime? CreateDate { get; set; }
        [Required(ErrorMessage = "bạn phải nhập ngươi viết đơn hàng")]
        public long? CreatID { get; set; }
        
        public long? Shiper { get; set; }
        [Required(ErrorMessage = "bạn phải nhập hình thức vận chuyển")]
        public long? ShipTypeID { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "bạn phải nhập tên ngupwì đặt hàng")]
        public string ShipName { get; set; }

        [StringLength(50)]
        public string ShipMobile { get; set; }

        [StringLength(50)]
        public string ShipEmail { get; set; }

        [StringLength(255)]
        public string ShipAdress { get; set; }

        [StringLength(50)]
        public string CouponSerial { get; set; }

        public int? Status { get; set; }
        //[Required(ErrorMessage = "bạn phải nhập ngày đặt hàng")]
        public DateTime? ShippedDate { get; set; }

        public decimal? TotalPrice { get; set; }
    }
}
