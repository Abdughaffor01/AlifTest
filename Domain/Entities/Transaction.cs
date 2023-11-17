using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Entities;
public class Transaction
{
    [Key]
    public int Id { get; set; }
    public decimal Amount { get; set; }
    [MaxLength(500)]
    public string Description { get; set; }
    
    public DateTime TransferAt { get; set; }
    
    [MaxLength(100)]
    
    public string From { get; set; }
    [MaxLength(100)]
    
    public string To { get; set; }
    public TransactionType Type { get; set; }
    public StatusTransfer StatusTransfer { get; set; }
}
