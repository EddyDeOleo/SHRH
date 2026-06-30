
using System.ComponentModel.DataAnnotations;


namespace SHRH.Data.Entities
{
    /// <summary>
    /// Representa un piso físico del hotel. El número de piso es único en todo el sistema.
    /// Un piso contiene múltiples habitaciones (relación 1:N).
    /// </summary>
    public class Floor
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Número de piso. Debe ser único (restricción configurada en el DbContext vía Fluent API).
        /// </summary>
        [Required]
        public int FloorNumber { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        // Navegación: un piso tiene muchas habitaciones.
        public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
    }

}
