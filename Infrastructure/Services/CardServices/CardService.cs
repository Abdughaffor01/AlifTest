using AutoMapper;
using System.Net;
using Domain.DTOs.CardDTOs;
using Domain.Entities;
using Domain.Response;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.CardServices;
public class CardService : ICardService
{
    private readonly UserManager<User> _userManager;
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public CardService(DataContext context, IMapper mapper, UserManager<User> userManager)
    {
        _context = context;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<Response<GetCardDto>> AddCartToOwner(string phoneNumber)
    {
        try
        {
            var r=new Random();
            var user = await _context.Users
                .FirstOrDefaultAsync(o => o.PhoneNumber == phoneNumber);
            if (user == null) return new Response<GetCardDto>(HttpStatusCode.NotFound,"not found owner");
            var card = new Card()
            {
                Balance = 0,
                Limit = 1500,
                Number = $"5058-2702-{r.Next(1000, 9999)}-{r.Next(1000, 9999)}",
                OwnerPhoneNumber = user.PhoneNumber!,
                SecurityCode = $"{r.Next(1000, 9999)}",
                TermKart = 4
            };
            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();
            var mapped = _mapper.Map<GetCardDto>(card);
            return new Response<GetCardDto>(mapped);
        }
        catch (Exception ex)
        {
            return new Response<GetCardDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<List<Card>>> GetCarts()
    {
        var card = await _context.Cards.ToListAsync();
        return new Response<List<Card>>(card);
    }

    public async Task<Response<GetCardDto>> GetCartWithNumber(string phoneNumber ,int cartNumber)
    {
        try
        {
            var user = await _userManager.Users.Select(u=>new GetCardDto()).FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
            if (user == null) return new Response<GetCardDto>(HttpStatusCode.BadRequest, "not found account");
            var card = await _context.Cards.Select(c => new GetCardDto()
            {
                PhoneNumber = c.OwnerPhoneNumber,
                SecurityCode = c.SecurityCode,
                TermKart = c.TermKart,
                Balance = c.Balance,
                Limit = c.Limit,
                Number = c.Number
            }).FirstOrDefaultAsync(c=>c.PhoneNumber==phoneNumber);
            if (card == null) return new Response<GetCardDto>(HttpStatusCode.NotFound, "No card");
            return new Response<GetCardDto>(card);
        }
        catch (Exception ex)
        {
            return new Response<GetCardDto>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}
