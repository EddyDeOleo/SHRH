using SHRH.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SHRH.Data.Services
{
    /// <summary>
    /// Tabla intermedia que asocia un <see cref="AdditionalService"/> a una <see cref="RoomCategory"/>,
    /// definiendo el precio específico de ese servicio para esa categoría
    /// (el mismo servicio puede tener precios distintos según la categoría de habitación).
    /// </summary>
    public class CategoryService
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int RoomCategoryId { get; set; }
        public virtual RoomCategory Category { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Service))]
        public int AdditionalServiceId { get; set; }
        public virtual AdditionalService Service { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
    }

}
