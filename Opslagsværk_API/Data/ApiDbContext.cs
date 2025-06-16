using Microsoft.EntityFrameworkCore;
using Opslagsværk.Shared;

namespace Opslagsværk_API.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AssignmentCategory> AssignmentCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(e => e.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(e => e.Username).IsUnique();

            // Table naming
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Assignment>().ToTable("Assignments");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<AssignmentCategory>().ToTable("AssignmentCategories");

            // Relationships

            // User - Role (Many-to-One)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.Role_id)
                .OnDelete(DeleteBehavior.Cascade);

            // Assignment - User (Many-to-One)
            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.User)
                .WithMany(u => u.Assignments)
                .HasForeignKey(a => a.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            // AssignmentCategories - Assignment (Many-to-One)
            modelBuilder.Entity<AssignmentCategory>()
                .HasOne(ac => ac.Assignment)
                .WithMany(a => a.AssignmentCategories)
                .HasForeignKey(ac => ac.AssignmentID)
                .OnDelete(DeleteBehavior.Cascade);

            // AssignmentCategories - Category (Many-to-One)
            modelBuilder.Entity<AssignmentCategory>()
                .HasOne(ac => ac.Category)
                .WithMany()
                .HasForeignKey(ac => ac.CategoryID)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}