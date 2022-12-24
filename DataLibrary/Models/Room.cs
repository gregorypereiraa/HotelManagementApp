namespace DataLibrary.Models;

public class Room : BaseEntity
{
    public int RoomNumber { get; set; }

    #region ForeignKey

    public int RoomTypeId { get; set; }
    public RoomType RoomType { get; set; }

    public IList<Booking> Bookings { get; set; } = new List<Booking>();

    #endregion
}