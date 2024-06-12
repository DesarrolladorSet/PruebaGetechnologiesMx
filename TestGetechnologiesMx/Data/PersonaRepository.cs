using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Backend.Data
{
	public class PersonaRepository : IPersonaRepository
	{
		private readonly Context context;

		public PersonaRepository(Context context)
		{
			this.context = context;
		}

		public async Task<ActionResult<Persona>> Create(Persona entity)
		{
			context.Set<Persona>().Add(entity);
			await context.SaveChangesAsync();
			return entity;
		}

		public async Task<ActionResult<Persona>> Delete(int id)
		{
			var entity = await context.Set<Persona>().FindAsync(id);
			if (entity == null)
			{
				throw new Exception("No existe registro");
			}

			context.Set<Persona>().Remove(entity);
			await context.SaveChangesAsync();

			return entity;
		}

		public async Task<ActionResult<Persona>> DeleteByIdentificacion(string identificacion)
		{
			var entity = await context.Set<Persona>().Where(w => w.Identificacion == identificacion).FirstOrDefaultAsync();
			if (entity == null)
			{
				throw new Exception("No existe registro");
			}

			var existFacturas = await context.Set<Factura>().Where(w => w.PersonaId == entity.Id).ToListAsync();
			if(existFacturas.Count > 0)
			{

				context.Set<Factura>().RemoveRange(existFacturas);
			}

			context.Set<Persona>().Remove(entity);
			await context.SaveChangesAsync();

			return entity;
		}

		public async Task<ActionResult<IEnumerable<Persona>>> GetAll()
		{
			return await context.Set<Persona>().ToListAsync();
		}


		public async Task<ActionResult<Persona>> GetByIdentificacion(string identificacion)
		{
			var entity = await context.Set<Persona>().Where(w => w.Identificacion == identificacion).FirstOrDefaultAsync();
			if (entity == null)
			{
				throw new Exception("No existe registro");
			}
			return entity;
		}

		public async Task<ActionResult<Persona>> Update(int id, Persona entity)
		{
			context.Entry(entity).State = EntityState.Modified;
			await context.SaveChangesAsync();
			return entity;
		}
	}
}
