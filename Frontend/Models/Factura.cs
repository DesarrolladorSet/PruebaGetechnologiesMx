using System.ComponentModel.DataAnnotations;

namespace Frontend.Models
{
	public class Factura
	{
		public int Id { get; set; }
		[Required]
		public int PersonaId { get; set; }
		[Required]
		public DateTime Fecha { get; set; }
		[Required]
		public decimal Monto { get; set; }
	}
}
