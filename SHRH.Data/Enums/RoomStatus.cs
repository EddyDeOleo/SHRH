
namespace SHRH.Data.Enums
{
    /// <summary>
    /// Estado operativo actual de una habitación, independiente de si tiene reservas futuras.
    /// </summary>
    public enum RoomStatus
    {
        Available = 1,
        Occupied = 2,
        UnderMaintenance = 3,
        Inactive = 4
    }
}
