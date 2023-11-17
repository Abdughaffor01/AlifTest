using Domain.DTOs.CardDTOs;
using Domain.Entities;
using Domain.Response;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("[controller]")]
[Authorize]
public class CardController : ControllerBase
{
    private readonly ICardService _service;
    public CardController(ICardService service) => _service = service;

    [HttpGet("GetCarts")]
    public async Task<Response<List<Card>>> GetCarts()
    {
        return await _service.GetCarts();
    }

    [HttpPost("AddCartToUser")]
    public async Task<Response<GetCardDto>> AddCartToUser()
    {
        var phoneNumber = User.Claims.FirstOrDefault(x => x.Type == "iss")!.Value;
        return await _service.AddCartToOwner(phoneNumber);
    }
}