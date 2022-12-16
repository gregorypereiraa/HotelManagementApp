using System.Data.SqlTypes;

namespace DataLibrary.Models;

public class RoomType : BaseEntity
{
    public string Title { get; set; }
    public string Descritption { get; set; }
    public double Price { get; set; }
}