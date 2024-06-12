using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace Backend.Data
{
	public interface IPersonaRepository : IBaseRepository<Persona>
	{
		Task<ActionResult<Persona>> GetByIdentificacion(string identificacion);
		Task<ActionResult<Persona>> DeleteByIdentificacion(string identificacion);
	}
}
