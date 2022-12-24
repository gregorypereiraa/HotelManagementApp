namespace DataLibrary.Models;

public class Guest : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    #region ForeignKey

    public IList<Booking> Bookings { get; set; } = new List<Booking>();

    #endregion
}