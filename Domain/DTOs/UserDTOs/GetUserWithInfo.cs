using Domain.Entities;

namespace Domain.DTOs.OwnerDTOs;
public class GetUserWithInfo:BaseUserDto
{
    public int Limit { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal Balance { get; set; }
    public string Status { get; set; }
    public ICollection<Card> Cards { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
}
