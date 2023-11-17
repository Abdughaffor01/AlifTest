using Microsoft.EntityFrameworkCore;
using System.Net;
using Domain.DTOs;
using Domain.Entities;
using Domain.Enums;
using Domain.Response;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services.Operation;
public class OperationService:IOperationService
{
    private readonly DataContext _context;
    private readonly UserManager<User> _userManager;
    public OperationService(DataContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<Response<string>> Payment(PaymentDto model)
    {
        if (model.Type == TransactionType.TransferToCard)
        {
            var card = await _context.Cards.FirstOrDefaultAsync(c => c.Number == model.Number);
            if (card == null) return new Response<string>(HttpStatusCode.NotFound,"not found card");
            card.Balance += model.Amount;
        }
        else if (model.Type == TransactionType.TransferToWallet)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(o => o.PhoneNumber == model.Number);
            if (user == null) return new Response<string>(HttpStatusCode.NotFound,"not found user");
            var wallet = await _context.Wallets.FirstOrDefaultAsync(w => w.UserId == user.Id);
            wallet.Balance += model.Amount;
        }
        var trk = new Transaction()
        {
            From = "NumberTerminal",
            To = $"{model.Number}",
            Amount = model.Amount,
            Description = $"From terminal Rudaki",
            TransferAt = DateTime.UtcNow,
            StatusTransfer = StatusTransfer.Done,
            Type = model.Type,
        };
        await _context.Transactions.AddAsync(trk);
        await _context.SaveChangesAsync();
        return new Response<string>("Successfuly payment");
    }
    
    public async Task<Response<string>> WithDraw(WithDrawDto model) {
        var card = await _context.Cards.FirstOrDefaultAsync(c=>c.Number==model.CardNumber);
        if (card == null) return new Response<string>(HttpStatusCode.NotFound,"no card");
        if (card.SecurityCode != model.Password) return new Response<string>(HttpStatusCode.BadRequest,"error password");
        if (card.Balance < model.Amount) return new Response<string>(HttpStatusCode.BadRequest,"no balance");
        card.Balance -= model.Amount;
        var trk = new Transaction()
        {
            From = $"{model.CardNumber}",
            To = "00000",
            Amount = model.Amount,
            Description = $"From bankomat 00000",
            TransferAt = DateTime.UtcNow,
            StatusTransfer = Domain.Enums.StatusTransfer.Done,
            Type = TransactionType.WithDraw,
        };
        await _context.Transactions.AddAsync(trk);
        await _context.SaveChangesAsync();
        return new Response<string>("Successfully withdraw");
    }
}
