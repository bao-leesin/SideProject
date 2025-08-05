using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryTag> CategoryTags { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupFunction> GroupFunctions { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<PartnerAuthConfig> PartnerAuthConfigs { get; set; }
        public DbSet<PartnerApiConfig> PartnerApiConfigs { get; set; }
        public DbSet<PartnerFieldMapping> PartnerFieldMappings { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProduct> UserProducts { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }
        public DbSet<Province> Provinces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many-to-many: Group <-> Function
            modelBuilder.Entity<GroupFunction>()
                .HasKey(gf => new { gf.GroupId, gf.FunctionId });
            modelBuilder.Entity<GroupFunction>()
                .HasOne(gf => gf.Group)
                .WithMany(g => g.Functions)
                .HasForeignKey(gf => gf.GroupId);
            modelBuilder.Entity<GroupFunction>()
                .HasOne(gf => gf.Function)
                .WithMany()
                .HasForeignKey(gf => gf.FunctionId);

            // Many-to-many: Order <-> Product
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });
            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.Products)
                .HasForeignKey(op => op.OrderId);
            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany()
                .HasForeignKey(op => op.ProductId);

            // Many-to-many: Product <-> Category
            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });
            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.Categories)
                .HasForeignKey(pc => pc.ProductId);
            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany()
                .HasForeignKey(pc => pc.CategoryId);

            // Many-to-many: Product <-> Tag
            modelBuilder.Entity<ProductTag>()
                .HasKey(pt => pt.Id);
            modelBuilder.Entity<ProductTag>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.Tags)
                .HasForeignKey(pt => pt.ProductId);

            // Many-to-many: User <-> Product
            modelBuilder.Entity<UserProduct>()
                .HasKey(up => new { up.UserId, up.ProductId });
            modelBuilder.Entity<UserProduct>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserProducts)
                .HasForeignKey(up => up.UserId);
            modelBuilder.Entity<UserProduct>()
                .HasOne(up => up.Product)
                .WithMany()
                .HasForeignKey(up => up.ProductId);

            // Many-to-many: User <-> Category
            modelBuilder.Entity<UserCategory>()
                .HasKey(uc => new { uc.UserId, uc.CategoryId });
            modelBuilder.Entity<UserCategory>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserCategories)
                .HasForeignKey(uc => uc.UserId);
            modelBuilder.Entity<UserCategory>()
                .HasOne(uc => uc.Category)
                .WithMany()
                .HasForeignKey(uc => uc.CategoryId);

            // Self-referencing: Category
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Children)
                .WithOne(c => c.Parent)
                .HasForeignKey(c => c.ParentId);

            // Self-referencing: Function
            modelBuilder.Entity<Function>()
                .HasMany(f => f.Children)
                .WithOne(f => f.Parent)
                .HasForeignKey(f => f.ParentId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
