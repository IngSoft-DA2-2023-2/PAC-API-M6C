using Microsoft.EntityFrameworkCore;
using PAC.Domain;

namespace PAC.DataAccess
{
	public class PacContext : DbContext
    {
        public PacContext() { }
        public PacContext(DbContextOptions options) : base(options) { }
        
        public virtual DbSet<Student> Students { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
                    {
                        entity.HasKey(e => e.Id).HasName("Id-Student");
            
                        entity.ToTable("students");
            
                        entity.Property(e => e.Id)
                            .IsUnicode(false)
                            .HasColumnName("id");
                        
                        entity.Property(e => e.Name)
                            .HasMaxLength(255)
                            .IsUnicode(false)
                            .HasColumnName("name");
                    });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-LEDJ6KJ\\SQLEXPRESS;Database=dbtienda;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}

