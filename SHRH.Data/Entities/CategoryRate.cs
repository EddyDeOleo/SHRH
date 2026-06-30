using SHRH.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SHRH.Data.Entities
{

    /// <summary>
    /// Tarifa por noche para una categoría de habitación en una temporada específica.
    /// REGLA DE NEGOCIO CRÍTICA: las tarifas NUNCA se actualizan (UPDATE) sobre un registro
    /// vigente. Para "modificar" una tarifa se cierra la vigencia actual asignando
    /// <see cref="ValidTo"/> y se crea un nuevo registro con un nuevo <see cref="ValidFrom"/>.
    /// Esto, sumado al snapshot guardado en <see cref="Reservation.AppliedRatePerNight"/>,
    /// garantiza que los cambios de tarifa nunca afecten reservas ya confirmadas.
    /// </summary>
    public class CategoryRate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int RoomCategoryId { get; set; }
        public virtual RoomCategory Category { get; set; } = null!;

        [Required]
        public Season Season { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PricePerNight { get; set; }

        /// <summary>Fecha desde la cual esta tarifa entra en vigencia.</summary>
        [Required]
        public DateTime ValidFrom { get; set; }

        /// <summary>
        /// Fecha hasta la cual estuvo vigente. Null mientras la tarifa esté activa/actual.
        /// </summary>
        public DateTime? ValidTo { get; set; }
    }
}
