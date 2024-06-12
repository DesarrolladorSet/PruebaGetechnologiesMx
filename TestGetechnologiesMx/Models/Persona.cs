using Backend.Data;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
	public class Persona: IEntity
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
