using SHRH.Data.Enums;
using System.ComponentModel.DataAnnotations;


namespace SHRH.Data.Entities
{

    /// <summary>
    /// Registro de auditoría genérico. Cubre el requerimiento estricto de registrar
    /// todas las creaciones, modificaciones y cancelaciones realizadas en el sistema.
    /// Se recomienda poblar esta tabla mediante un SaveChangesInterceptor de EF Core
    /// en lugar de invocarla manualmente desde cada servicio (evita duplicación, DRY).
    /// </summary>
    public class AuditLog
    {
        [Key]
        public int Id { get; set; }

        /// <summary>Nombre de la entidad afectada (ej. "Reservation", "CategoryRate").</summary>
        [Required]
        [MaxLength(100)]
        public string EntityName { get; set; } = string.Empty;

        /// <summary>Clave primaria del registro afectado, almacenada como texto.</summary>
        [Required]
        [MaxLength(50)]
        public string EntityId { get; set; } = string.Empty;

        [Required]
        public AuditActionType ActionType { get; set; }

        /// <summary>Identificador del usuario del sistema que ejecutó la acción.</summary>
        [Required]
        [MaxLength(150)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        /// <summary>Valores anteriores serializados en JSON. Null si la acción fue una creación.</summary>
        public string? OldValues { get; set; }

        /// <summary>Valores nuevos serializados en JSON. Null si la acción fue una eliminación.</summary>
        public string? NewValues { get; set; }
    }

}
