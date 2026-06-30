
using SHRH.Data.Services;
using System.ComponentModel.DataAnnotations;


namespace SHRH.Data.Entities
{
    /// <summary>
    /// Categoría de habitación (ej. Estándar, Suite, Deluxe).
    /// Define la capacidad máxima de huéspedes y agrupa las tarifas por temporada
    /// y los servicios adicionales disponibles para esa categoría.
    /// </summary>
    public class RoomCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        /// <summary>
        /// Capacidad máxima de huéspedes permitida para esta categoría.
        /// Se utiliza para validar la cantidad de huéspedes al crear una reserva.
        /// </summary>
        [Required]
        public int MaxGuestCapacity { get; set; }

        public bool IsActive { get; set; } = true;

        // Navegación
        public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
        public virtual ICollection<CategoryRate> Rates { get; set; } = new List<CategoryRate>();
        public virtual ICollection<CategoryService> CategoryServices { get; set; } = new List<CategoryService>();
    }
}
