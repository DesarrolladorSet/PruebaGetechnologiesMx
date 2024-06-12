using Backend.Data;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
	public class Factura: IEntity
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
