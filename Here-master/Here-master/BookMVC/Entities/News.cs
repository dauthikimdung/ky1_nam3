namespace BookMVC.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public long ID { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        public long? Created { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? TypeID { get; set; }

        public bool? isPublic { get; set; }

        [StringLength(10)]
        public string isHomePage { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(100)]
        public string Author { get; set; }

        public string Content { get; set; }
    }
}
