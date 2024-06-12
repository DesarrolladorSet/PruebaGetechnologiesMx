using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Data
{
	public interface IFacturarepository : IBaseRepository<Factura>
	{
		Task<ActionResult<IEnumerable<Factura>>> GetByPersona(int personaId);
	}
}
