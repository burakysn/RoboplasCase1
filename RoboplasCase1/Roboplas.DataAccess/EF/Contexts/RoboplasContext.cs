using Microsoft.EntityFrameworkCore;
using Roboplas.Model.Entities;

namespace Roboplas.DataAccess.EF.Contexts
{
    public class RoboplasContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("SERVER =.\\SQLEXPRESS; Database = RoboplasCase; trusted_connection = true;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Duty> Dutys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("Users").HasKey("Id");

                e.Property(a => a.Id).HasColumnType("int").UseIdentityColumn();
                e.Property(a => a.Email).HasMaxLength(50);
                e.Property(a => a.FullName).HasMaxLength(32);
                e.Property(a => a.Password).HasMaxLength(32);
                e.Property(a => a.UserName).HasMaxLength(32);
            });
            modelBuilder.Entity<Duty>(e =>
            {
                e.ToTable("Dutys").HasKey("Id");

                e.Property(a=>a.Id).HasColumnType("int").UseIdentityColumn();
                e.Property(a => a.Title).HasMaxLength(50);
                e.Property(a => a.Description).HasMaxLength(128);
                e.Property(a => a.Status).HasDefaultValue(false);
                e.Property(a => a.LastDate).HasColumnType("datetime").IsRequired(false);
                e.HasOne(typeof(User)).WithMany().HasForeignKey("UserId");
            });
        }
    }
}
