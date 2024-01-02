using Microsoft.EntityFrameworkCore;

namespace CoreAndFood.Models
{
	public class Context : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer("server=DESKTOP-LMK3OGQ; database=DbCoreAndFood; integrated security=true; TrustServerCertificate=True;");
		}

		public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
		public DbSet<Admin> Admins { get; set; }
    }
}
