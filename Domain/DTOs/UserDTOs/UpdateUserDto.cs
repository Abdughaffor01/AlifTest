namespace Domain.DTOs.OwnerDTOs;
public class UpdateUserDto:BaseUserDto
{
    public string? PhoneNumber { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
