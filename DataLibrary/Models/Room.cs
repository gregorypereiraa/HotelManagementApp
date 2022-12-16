using System.ComponentModel.DataAnnotations.Schema;

namespace DataLibrary.Models;

public class Room : BaseEntity
{
    public int RoomNumber { get; set; }
    public int RoomTypeId { get; set; }
    public RoomType RoomType { get; set; }
}