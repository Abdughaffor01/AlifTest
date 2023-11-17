using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Seed;

public class Seeder
{
    private readonly UserManager<User> _userManager;
    private readonly DataContext _context;
    public Seeder(UserManager<User> userManager, DataContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task<bool> SeedUser()
    {
        var res1 = await _userManager.FindByNameAsync("Client1");
        if (res1 != null) return false;
        
        var user1 = new User()
        {
            UserName = "Client1",
            PhoneNumber = "+992987849660",
        };
        var user2 = new User()
        {
            UserName = "Client2",
            PhoneNumber = "+992987849660",
        };
        var user3 = new User()
        {
            UserName = "Client3",
            PhoneNumber = "+992987849660",
        };
        

        await _userManager.CreateAsync(user1, "User1");
        await _userManager.CreateAsync(user2, "User1");
        await _userManager.CreateAsync(user3, "User1");

        var wallets = new List<Wallet>()
        {
            new Wallet(){UserId = user1.Id,Balance = 500},
            new Wallet(){UserId = user2.Id,Balance = 1000},
            new Wallet(){UserId = user3.Id,Balance = 2200},
        };
        
        await _context.Wallets.AddRangeAsync(wallets);
        await _context.SaveChangesAsync();
        
        return true;
    }
}