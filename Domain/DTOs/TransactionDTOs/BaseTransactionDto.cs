namespace Domain.DTOs.TransactionDTOs;
public class BaseTransactionDto
{
    public decimal Amount { get; set; }
    public string Description { get; set; } 
    public string From { get; set; }
    public string? To  { get; set; }
}
