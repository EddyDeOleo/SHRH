using SHRH.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SHRH.Data.Entities
{

    /// <summary>
    /// Habitación física del hotel. Pertenece a un único piso y a una única categoría.
    /// </summary>
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string RoomNumber { get; set; } = string.Empty;

        public RoomStatus Status { get; set; } = RoomStatus.Available;

        [Required]
        [ForeignKey(nameof(Floor))]
        public int FloorId { get; set; }
        public virtual Floor Floor { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Category))]
        public int RoomCategoryId { get; set; }
        public virtual RoomCategory Category { get; set; } = null!;

        // Navegación: una habitación puede tener muchas reservas a lo largo del tiempo.
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
