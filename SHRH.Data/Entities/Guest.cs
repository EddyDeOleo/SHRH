using System.ComponentModel.DataAnnotations;


namespace SHRH.Data.Entities
{
    /// <summary>
    /// Huésped/cliente que realiza una o más reservas en el hotel.
    /// </summary>
    public class Guest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(30)]
        public string DocumentNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [MaxLength(30)]
        public string? PhoneNumber { get; set; }

        // Navegación
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }

}
