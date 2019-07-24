namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DayOfBirth { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public bool Status { get; set; }

        [StringLength(20)]
        public string GroupID { get; set; }

        public int? BookCount { get; set; }

        public int? OrderCount { get; set; }

        public int? OrderCancel { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public long? ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeyword { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }
    }
}
