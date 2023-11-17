using Domain.Enums;

namespace Domain.DTOs.TransactionDTOs;

public class AddTransactionDto:BaseTransactionDto
{
    public TransactionType Type { get; set; } 
}
