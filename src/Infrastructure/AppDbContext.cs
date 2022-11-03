using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options)
		: base(options)
	{
	}

	//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	//{
	//	optionsBuilder.UseNpgsql("");

	//	base.OnConfiguring(optionsBuilder);
	//}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

		base.OnModelCreating(modelBuilder);
	}
}