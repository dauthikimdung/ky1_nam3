namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SachDbContext : DbContext
    {
        public SachDbContext()
            : base("name=SachDbContext")
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<BookCategory> BookCategory { get; set; }
        public virtual DbSet<CartItem> CartItem { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Content> Content { get; set; }
        public virtual DbSet<ContentTag> ContentTag { get; set; }
        public virtual DbSet<Coupon> Coupon { get; set; }
        public virtual DbSet<Credential> Credential { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Footer> Footer { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuType> MenuType { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsType> NewsType { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Order_Detail> Order_Detail { get; set; }
        public virtual DbSet<Publisher> Publisher { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<ShippingType> ShippingType { get; set; }
        public virtual DbSet<Slide> Slide { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<SystemConfig> SystemConfig { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserGroup> UserGroup { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.UserName)
                .IsFixedLength();

            modelBuilder.Entity<Author>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Book>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Book>()
                .Property(e => e.Inventory)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Book>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.MetaDescription)
                .IsFixedLength();

            modelBuilder.Entity<BookCategory>()
                .Property(e => e.MetaTitle)
                .IsFixedLength();

            modelBuilder.Entity<BookCategory>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<BookCategory>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BookCategory>()
                .Property(e => e.MetaDescription)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .Property(e => e.MetaTitle)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .Property(e => e.SeoTitle)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.MetaDescription)
                .IsFixedLength();

            modelBuilder.Entity<Content>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Content>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Content>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Content>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Content>()
                .Property(e => e.MetaDescription)
                .IsFixedLength();

            modelBuilder.Entity<ContentTag>()
                .Property(e => e.TagID)
                .IsUnicode(false);

            modelBuilder.Entity<Coupon>()
                .Property(e => e.Serial)
                .IsUnicode(false);

            modelBuilder.Entity<Coupon>()
                .Property(e => e.Discount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Credential>()
                .Property(e => e.UserGroupID)
                .IsUnicode(false);

            modelBuilder.Entity<Credential>()
                .Property(e => e.RoleID)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.isHomePage)
                .IsFixedLength();

            modelBuilder.Entity<NewsType>()
                .Property(e => e.Order)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order>()
                .Property(e => e.ShipMobile)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.CouponSerial)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.TotalPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order_Detail>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Publisher>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Publisher>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Publisher>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Publisher>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Publisher>()
                .Property(e => e.MetaDescription)
                .IsFixedLength();

            modelBuilder.Entity<Role>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<ShippingType>()
                .Property(e => e.Cost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Slide>()
                .Property(e => e.Where)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.MetaDescription)
                .IsFixedLength();

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Tag>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.GroupID)
                .IsUnicode(false);

            modelBuilder.Entity<UserGroup>()
                .Property(e => e.ID)
                .IsUnicode(false);
        }
    }
}
