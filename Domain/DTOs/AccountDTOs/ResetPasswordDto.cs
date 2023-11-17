using System.ComponentModel.DataAnnotations;
namespace Domain;
public class ResetPasswordDto
{
    public string Token { get; set; }
    public string Email { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}