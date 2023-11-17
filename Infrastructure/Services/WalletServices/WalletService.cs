using System.Net;
using Domain.Entities;
using Domain.Enums;
using Domain.Response;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.WalletServices;

public class WalletService : IWalletService
{
    private readonly DataContext _context;
    private readonly UserManager<User> _userManager;

    public WalletService(DataContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }


    public async Task<Response<string>> Payment(string phoneNumber, decimal amount)
    {
        try
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u=>u.PhoneNumber==phoneNumber);
            if (user != null) return new Response<string>(HttpStatusCode.NotFound, "not found account");
            var wallet = await _context.Wallets.FirstOrDefaultAsync(w => w.UserId == user!.Id);
            if (user!.StatusUser == StatusUser.Unidentified)
            {
                if (wallet!.Balance + amount > 10000) 
                    return new Response<string>(HttpStatusCode.BadRequest, "The specified amount exceeds the limit! Please identify yourself to exceed the limit to 100,000.");
                wallet.Balance += amount;
                await _context.SaveChangesAsync();
                return new Response<string>("Successfully");
            }
            else
            {
                if (wallet!.Balance + amount > 100000) 
                    return new Response<string>(HttpStatusCode.BadRequest, "The specified amount exceeds the limit!");
                wallet.Balance += amount;
                await _context.SaveChangesAsync();
                return new Response<string>("Successfully");
            }
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<string>> CheckWallet(string phoneNumber)
    {
        try
        {
            var checkWallet = await _userManager.Users
                .FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
            if (checkWallet != null) return new Response<string>($"{checkWallet.FirstName!.First()}.${checkWallet.LastName!.First()}");
            return new Response<string>(HttpStatusCode.NotFound,"not found wallet");
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}