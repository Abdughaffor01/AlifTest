using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class User : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    
    public StatusUser StatusUser { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public Wallet Wallet { get; set; }

    public IEnumerable<Card> Cards { get; set; }

    public IEnumerable<Transaction> Transactions { get; set; }
}