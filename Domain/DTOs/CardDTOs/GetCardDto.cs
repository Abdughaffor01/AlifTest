namespace Domain.DTOs.CardDTOs;
public class GetCardDto
{
    public int CardId { get; set; }
    public string Number { get; set; }
    public string PhoneNumber { get; set; }
    public decimal Balance { get; set; }
    public int TermKart { get; set; }
    public int Limit { get; set; }
    public string SecurityCode { get; set; }
}
