using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
	public class VentasController : Controller
	{
		private readonly FacturaRepository facturaRepository;
		private readonly ILogger<DirectorioController> _log;
		public VentasController(Context context, ILogger<DirectorioController> logger)
		{
			_log = logger;
			facturaRepository = new(context);
		}

		[HttpGet("FindFacturasByPersonaId")]
		public async Task<ActionResult<IEnumerable<Factura>>> FindFacturasByPersonaId(int personaId)
		{
			try
			{
				return await facturaRepository.GetByPersona(personaId);
			}
			catch (Exception ex)
			{
				_log.LogError(ex.ToString());
				return NoContent();
			}
		}

		[HttpPost("CreateFactura")]
		public async Task<ActionResult<Factura>> CreateFactura(Factura factura)
		{
			try
			{
				return await facturaRepository.Create(factura);
			}
			catch (Exception ex)
			{
				_log.LogError(ex.ToString());
				return NoContent();
			}
		}
	}
}
