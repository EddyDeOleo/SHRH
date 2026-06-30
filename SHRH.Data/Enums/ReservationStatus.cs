
namespace SHRH.Data.Enums
{

    /// <summary>
    /// Ciclo de vida de una reserva. Una vez en <see cref="Confirmed"/>,
    /// el costo total queda congelado y no se ve afectado por cambios
    /// posteriores en tarifas de categoría o precios de servicios.
    /// </summary>
    public enum ReservationStatus
    {
        Pending = 1,
        Confirmed = 2,
        CheckedIn = 3,
        CheckedOut = 4,
        Cancelled = 5
    }
}
