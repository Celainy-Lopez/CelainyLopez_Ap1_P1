using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CelainyLopez_Ap1_P1.Models;

public class Cobros
{
    [Key]
    public int CobroId { get; set; }

    public DateTime? Fecha {get;set;} = DateTime.Now;

    [ForeignKey("Deudor")]
    [Required(ErrorMessage = "El campo es obligatorio")]
    [Range(1, int.MaxValue, ErrorMessage = "El id debe ser mayor que 0")]
    public int DeudorId { get; set; }
    public Deudores? Deudor { get; set; }


    [ForeignKey("PrestamoId")]
    public int PrestamoId { get; set; }
    public Prestamos? Prestamo { get; set; }

    [ForeignKey("CobroId")]
    public ICollection<CobroDetalle> CobroDetalle { get; set; } = new List<CobroDetalle>();
}
