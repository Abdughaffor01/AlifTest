using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Cart
{
    [Key,MaxLength(100)]
    public string CartNumber { get; set; }

    public string? UserId { get; set; }
    public User User { get; set; }
    
    public decimal Balance { get; set; }
    public int TermKart { get; set; }
    public int Limit { get; set; }

    [MaxLength(4)]
    public string SecurityCode { get; set; }
}