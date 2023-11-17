using Domain.Enums;

namespace Domain.DTOs;
public class PaymentDto
{
    public string Number { get; set; }
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }
}
