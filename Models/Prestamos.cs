using System.ComponentModel.DataAnnotations;

namespace CelainyLopez_Ap1_P1.Models;

public class Prestamos
{
	[Key]
	public int PrestamoId {  get; set; }

	[Required(ErrorMessage ="Ingrese un nombre valido")]
	public string Deudor {  get; set; }

	[Required(ErrorMessage ="Ingrese un concepto valido")]
	public string Concepto { get; set; }

	[Required(ErrorMessage ="Ingrese un monto valido")]
	[Range(0.1, float.MaxValue, ErrorMessage ="El monto debe ser mayor a 0")]
	public float? Monto { get; set; }
}
