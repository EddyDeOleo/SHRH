using SHRH.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SHRH.Data.Services
{
    /// <summary>
    /// Detalle de un servicio adicional contratado dentro de una reserva específica.
    /// <see cref="UnitPrice"/> es un snapshot del precio de <see cref="CategoryService"/>
    /// al momento de la reserva, para no verse afectado por cambios futuros de precio.
    /// </summary>
    public class ReservationService
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Reservation))]
        public int ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Service))]
        public int AdditionalServiceId { get; set; }
        public virtual AdditionalService Service { get; set; } = null!;

        [Required]
        public int Quantity { get; set; } = 1;

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal UnitPrice { get; set; }
    }

}
