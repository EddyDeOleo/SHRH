using SHRH.Data.Services;
using System.ComponentModel.DataAnnotations;


namespace SHRH.Data.Entities
{
    /// <summary>
    /// Catálogo general de servicios adicionales ofrecidos por el hotel (spa, desayuno, etc.).
    /// El precio real cobrado depende de la categoría de habitación, definido en <see cref="CategoryService"/>.
    /// </summary>
    public class AdditionalService
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        // Navegación
        public virtual ICollection<CategoryService> CategoryServices { get; set; } = new List<CategoryService>();
    }
}
