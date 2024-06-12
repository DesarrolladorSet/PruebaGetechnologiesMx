using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
	public class FacturaRepository : IFacturarepository
	{
		private readonly Context context;

		public FacturaRepository(Context context)
		{
			this.context = context;

		}
		public async Task<ActionResult<Factura>> Create(Factura entity)
		{
			context.Set<Factura>().Add(entity);
			await context.SaveChangesAsync();
			return entity;
		}

		public async Task<ActionResult<Factura>> Delete(int id)
		{
			var entity = await context.Set<Factura>().FindAsync(id);
			if (entity == null)
			{
				throw new Exception("No existe registro");
			}

			context.Set<Factura>().Remove(entity);
			await context.SaveChangesAsync();

			return entity;
		}

		public async Task<ActionResult<IEnumerable<Factura>>> GetAll()
		{
			return await context.Set<Factura>().ToListAsync();
		}

		public async Task<ActionResult<IEnumerable<Factura>>> GetByPersona(int personaId)
		{
			var entity = await context.Set<Factura>().Where(w => w.PersonaId == personaId).ToListAsync();
			if (entity == null)
			{
				throw new Exception("No existe registro");
			}
			return entity;
		}

		public async Task<ActionResult<Factura>> Update(int id, Factura entity)
		{
			context.Entry(entity).State = EntityState.Modified;
			await context.SaveChangesAsync();
			return entity;
		}
	}
}
