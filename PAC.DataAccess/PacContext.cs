using Microsoft.EntityFrameworkCore;
using PAC.Domain;

namespace PAC.DataAccess
{
	public class PacContext : DbContext
    {
        public PacContext() { }
        public DbSet<Student> Students { get; set; }
        public PacContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(u => u.Id);
            modelBuilder.Entity<Student>().Property(u => u.Id).ValueGeneratedOnAdd();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = 127.0.0.1; Database = starwarsdb; User Id = sa; Password = MyPass@word; TrustServerCertificate=True;");
        }
    }
}

