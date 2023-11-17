namespace Domain.DTOs.OwnerDTOs;
public class GetUserDto:BaseUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Limit { get; set; }
    public decimal Balance { get; set; }
    public string Status { get; set; }
}
