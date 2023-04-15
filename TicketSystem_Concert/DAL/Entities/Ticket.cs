using System.ComponentModel.DataAnnotations;

namespace TicketSystem_Concert.DAL.Entities
{
	public class Ticket
	{
		#region Properties
		[Display(Name = "Ticket.")]
		[Key]
		[MaxLength(100)]
		[Required(ErrorMessage = "El campo [0] es necesario.")]
		public string? Id { get; set; }

		[Display(Name = "Fecha de uso de la boleta.")]
		public DateTime? UseData { get; set; }

		[Display(Name = "Uso la boleta.")]
		public bool? IsUsed { get; set; }

		[Display(Name = "Portería de ingreso.")]
		public bool? EntranceGate { get; set; }
		#endregion
	}
}
