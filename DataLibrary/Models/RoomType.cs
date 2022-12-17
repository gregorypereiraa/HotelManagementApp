using System.Data.SqlTypes;

namespace DataLibrary.Models;

public class RoomType : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }

    #region ForeignKey

    public IList<Room>Rooms { get; set; }
    
    #endregion
}