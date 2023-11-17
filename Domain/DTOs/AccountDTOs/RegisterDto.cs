using System.ComponentModel.DataAnnotations;

namespace Domain;

public class RegisterDto
{
    public string PhoneNumber { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}