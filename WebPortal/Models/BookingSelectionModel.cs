using System.ComponentModel.DataAnnotations;

namespace WebPortal.Models;

public class BookingSelectionModel
{
    [Required] public DateTime CheckIn { get; set; } = DateTime.Now;

    [Required] public DateTime CheckOut { get; set; } = DateTime.Now.AddDays(1);

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Select a room type")]
    public int RoomTypeId { get; set; }
}