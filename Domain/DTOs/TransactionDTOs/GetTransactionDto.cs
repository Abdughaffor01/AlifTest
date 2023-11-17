namespace Domain.DTOs.TransactionDTOs;
public class GetTransactionDto:BaseTransactionDto
{
    public string StatusTransfer { get; set; }
    public string Type { get; set; }
    public DateTime TransferAt { get; set; }
}
