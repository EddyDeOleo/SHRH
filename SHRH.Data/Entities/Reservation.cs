using SHRH.Data.Enums;
using SHRH.Data.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SHRH.Data.Entities
{

    /// <summary>
    /// Reserva de una habitación. Genera un código único (GUID) al crearse.
    /// IMPORTANTE: <see cref="AppliedRatePerNight"/> y <see cref="TotalAmount"/> son SNAPSHOTS
    /// calculados y persistidos en el momento de la confirmación. Cambios posteriores en
    /// <see cref="CategoryRate"/> o en <see cref="CategoryService"/> NO deben recalcular
    /// estos valores: una reserva confirmada conserva el precio con el que fue contratada.
    /// </summary>
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Código único de la reserva, generado automáticamente (Guid.NewGuid()) al crearse.
        /// Es el identificador visible/comunicable al huésped (no el Id interno).
        /// </summary>
        [Required]
        public Guid BookingCode { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey(nameof(Guest))]
        public int GuestId { get; set; }
        public virtual Guest Guest { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Room))]
        public int RoomId { get; set; }
        public virtual Room Room { get; set; } = null!;

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        /// <summary>
        /// Cantidad de huéspedes para esta reserva. Debe validarse en la capa de servicio
        /// contra <see cref="RoomCategory.MaxGuestCapacity"/> de la categoría de la habitación.
        /// </summary>
        [Required]
        public int GuestsCount { get; set; }

        /// <summary>
        /// Snapshot de la tarifa por noche vigente al momento de confirmar la reserva.
        /// No se recalcula si la tarifa de la categoría cambia después.
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal AppliedRatePerNight { get; set; }

        /// <summary>
        /// Costo total = (noches * AppliedRatePerNight) + suma de servicios adicionales.
        /// Persistido como snapshot, no como propiedad calculada en tiempo real.
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }

        [Required]
        public ReservationStatus Status { get; set; } = ReservationStatus.Pending;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navegación: servicios adicionales contratados en esta reserva.
        public virtual ICollection<ReservationService> ReservationServices { get; set; } = new List<ReservationService>();
    }
}
