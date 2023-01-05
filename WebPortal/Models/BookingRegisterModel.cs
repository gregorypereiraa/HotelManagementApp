using System.ComponentModel.DataAnnotations;

namespace WebPortal.Models;

public class BookingRegisterModel
{
    [Required]
    [MinLength(2, ErrorMessage = "Please enter your first name")]
    public string FirstName { get; set; }

    [Required]
    [MinLength(2, ErrorMessage = "Please enter your last name")]
    public string LastName { get; set; }

    [Required]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$",
        ErrorMessage = "Please enter a valid e-mail address. ")]

    public string EmailAdress { get; set; }

    [Required]
    [RegularExpression(@"^04\d{8}$",
        ErrorMessage =
            "Please enter a valid Australian phone number starting with 04 and having a total of 10 digits.")]
    public string Phone { get; set; }
}