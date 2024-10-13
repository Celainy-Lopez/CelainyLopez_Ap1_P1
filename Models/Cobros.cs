using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelainyLopez_Ap1_P1.Models;

public class Cobros
{
    [Key]
    public int CobroId { get; set; }

    public DateTime? Fecha {get;set;} = DateTime.Now;
    public int PrestamoId { get; set; } 

    public float? Monto { get; set; }   

    [ForeignKey("Deudor")]
    [Range(1, int.MaxValue, ErrorMessage = "Seleccione una opción valida")]
    public int DeudorId { get; set; }
    public Deudores? Deudor { get; set; }

	[ForeignKey("CobroId")]
    public ICollection<CobroDetalle> CobroDetalle { get; set; } = new List<CobroDetalle>();
}
