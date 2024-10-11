using System.ComponentModel.DataAnnotations;

namespace CelainyLopez_Ap1_P1.Models;

public class Deudores
{
	[Key]
	public int DeudorId { get; set; }
	[Required(ErrorMessage = "Ingrese un nombre valido")]
	[RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "Los nombres solo debe contener letras.")]
	public string? Nombres {  get; set; }
}
