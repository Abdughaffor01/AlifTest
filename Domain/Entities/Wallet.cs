using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Wallet
{
    [Key,MaxLength(100)]
    public string? UserId { get; set; }
    public User User { get; set; }
    
    public decimal Balance { get; set; }
}