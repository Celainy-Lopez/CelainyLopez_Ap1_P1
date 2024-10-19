using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelainyLopez_Ap1_P1.Models;

public class CobrosDetalle
{
    [Key]
    public int DetalleId { get; set; }

    [ForeignKey("Cobro")]
    public int CobroId;
    public Cobros? Cobro { get; set; }

	[ForeignKey("Prestamo")]
	[Range(1, int.MaxValue, ErrorMessage = "Seleccione una opción valida")]
	public int PrestamoId;
    public Prestamos? Prestamo { get; set; }

    [Required(ErrorMessage = "Ingrese un valor valido")]
    [Range(0.1, float.MaxValue, ErrorMessage = "El valor cobrado debe ser mayor que 0")]
    public float? ValorCobrado { get; set; }

}
