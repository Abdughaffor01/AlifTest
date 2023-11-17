namespace Domain.DTOs.TransactionDTOs;
public class GetTransitionByNumber
{
    public DateTime TransferAt { get; set; }
    public string  Description { get; set; }
    public string From { get; set; }
    public decimal Amount { get; set; }
    public string Type { get; set; }
}
