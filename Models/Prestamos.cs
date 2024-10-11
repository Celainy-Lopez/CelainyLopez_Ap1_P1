using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelainyLopez_Ap1_P1.Models;

public class Prestamos
{
	[Key]
	public int PrestamoId {  get; set; }

	[Required(ErrorMessage ="Ingrese un concepto valido")]
    [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "El concepto solo debe contener letras.")]

    public string Concepto { get; set; }

	[Required(ErrorMessage ="Ingrese un monto valido")]
	[Range(0.1, float.MaxValue, ErrorMessage ="El monto debe ser mayor a 0")]
	public float? Monto { get; set; }

	[Required(ErrorMessage = "Ingrese un balance valido")]
	[Range(0.1, float.MaxValue, ErrorMessage = "El balance debe ser mayor que 0")]
	public float? Balance { get; set; }

	[ForeignKey("Deudor")]
    [Range(1, int.MaxValue, ErrorMessage = "Por favor, seleccione una opción válida")]
    public int DeudorId { get; set; }
	public Deudores? Deudor { get; set; }
}
