
using System.ComponentModel.DataAnnotations;

namespace Frontend.Models
{
	public class Persona
	{
		public int Id { get; set; }
		[Required]
		public string Nombre { get; set; }
		[Required]
		public string ApellidoPaterno { get; set; }
		public string? ApellidoMaterno { get; set; }
		[Required]
		public string Identificacion { get; set; }
	}
}
