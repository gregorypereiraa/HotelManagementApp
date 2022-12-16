using System.Data.SqlTypes;

namespace DataLibrary.Models;

public class Booking : BaseEntity
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public bool CheckedIn { get; set; }

    public double Cost
    {
        get
        {
            var days= End-Start;
            var cost = Room.RoomType.Price;
            return days.Days * cost;
        }
    }

    public int RoomsId { get; set; }
    public Room Room { get; set; }
    
    public int GuestId { get; set; }
    public Guest Guest { get; set; }
}