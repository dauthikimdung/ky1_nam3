namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Book")]
    public partial class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

     
        [StringLength(50)]

        [Required(ErrorMessage = "Bạn phải nhập mã  sách")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên sách")]
        [StringLength(250)]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Bạn phải nhập tên tác giả")]
        public int? Author { get; set; }

        //[Required(ErrorMessage = "Bạn phải nhập tên nhà phát hành")]
        public int? Released { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên NXB")]
        public int? Publisher { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập số trang")]
        public int? NumberPage { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập trọng lượng")]
        public int? Weight { get; set; }

        
        [StringLength(20)]
        public string Form { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập ngày xuất bản")]
        [Column(TypeName = "date")]
        public DateTime? PublishDate { get; set; }


        public int? Buys { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập giá sách")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập giá gốc")]
        public decimal? PromotionPrice { get; set; }

        //[Required(ErrorMessage = "Bạn phải nhập loại sách")]
        public long? CategoryID { get; set; }

        public int? ViewCount { get; set; }

        public int? LikeCount { get; set; }

        public decimal? Inventory { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        public bool? Status { get; set; }

       
        [StringLength(250)]
        public string Image { get; set; }

       
        [AllowHtml]
        public string Description { get; set; }

        [Column(TypeName = "xml")]
        public string Modelmage { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeyword { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }
    }
}
