using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
	public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options) : base(options)
		{ }

		public DbSet<Persona> Persona { get; set; }
		public DbSet<Factura> Factura { get; set; }
	}
}
