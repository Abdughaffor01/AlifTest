using Domain.DTOs.CardDTOs;
using Domain.Entities;
using Domain.Response;

namespace Infrastructure.Services;
public interface ICardService
{
    Task<Response<List<Card>>> GetCarts();
    Task<Response<GetCardDto>> AddCartToOwner(string phoneNumber);
    Task<Response<GetCardDto>> GetCartWithNumber(string phoneNumber, int cartNumber);
}
