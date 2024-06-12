using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
	[Consumes("application/json")]
	[Produces("application/json")]
	public class DirectorioController : Controller
	{
		private readonly PersonaRepository personaRepository;
		private readonly ILogger<DirectorioController> _log;
		public DirectorioController(Context context, ILogger<DirectorioController> logger)
		{
			_log = logger;
			personaRepository = new(context);
		}

		[HttpGet("FindPersonaByIdentificacion")]
		public async Task<ActionResult<Persona>> FindPersonaByIdentificacion(string identificacion)
		{
			try
			{
				return await personaRepository.GetByIdentificacion(identificacion);
			}
			catch (Exception ex)
			{
				_log.LogError(ex.ToString());
				return NoContent();
			}
		}

		[HttpGet("FindPersonas")]
		public async Task<ActionResult<IEnumerable<Persona>>> FindPersonas()
		{
			try
			{
				return await personaRepository.GetAll();
			}
			catch (Exception ex)
			{
				_log.LogError(ex.ToString());
				return NoContent();
			}
		}

		[HttpPost("CreatePersona")]
		public async Task<ActionResult<Persona>> CreatePersona([FromBody] Persona persona)
		{
			try
			{
				return await personaRepository.Create(persona);
			}
			catch (Exception ex)
			{
				_log.LogError(ex.ToString());
				return NoContent();
			}
		}


		[HttpDelete("DeletePersonaByIdentificacion")]
		public async Task<ActionResult<Persona>> DeletePersonaByIdentificacion(string identificacion)
		{
			try
			{
				return await personaRepository.DeleteByIdentificacion(identificacion);
			}
			catch (Exception ex)
			{
				_log.LogError(ex.ToString());
				return NoContent();
			}
		}
	}
}
