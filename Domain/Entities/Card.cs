using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
public class Card
{
    [Key]
    public int CardId { get; set; }

    [MaxLength(100)]
    public string Number { get; set; }

    [ForeignKey("User")]
    public string OwnerPhoneNumber { get; set; }
    
    public User User { get; set; }
    
    public decimal Balance { get; set; }

    [MaxLength(50)]
    public int TermKart { get; set; }
    public int Limit { get; set; }

    [MaxLength(4)]
    public string SecurityCode { get; set; }
}
