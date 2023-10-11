using Microsoft.EntityFrameworkCore;
using PAC.Domain;

namespace PAC.DataAccess
{
	public class PacContext : DbContext
    {
        public PacContext() { }
        public PacContext(DbContextOptions options) : base(options) { }
        
        public virtual DbSet<Student>? Students { get; set; }   

        protected override void OnModelCreating(ModelBuilder modelBuilder){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = 127.0.0.1; Database = starwarsdb; User Id = sa; Password = MyPass@word; TrustServerCertificate=True;");
        }
    }
}

