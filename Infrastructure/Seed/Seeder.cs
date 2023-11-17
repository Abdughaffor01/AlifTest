using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Seed;

public class Seeder
{
    private readonly UserManager<IdentityUser> _userManager;
    public Seeder(UserManager<IdentityUser> userManager)=>_userManager = userManager;

    public async Task<bool> SeedUser()
    {
        var existing = await _userManager.FindByNameAsync("admin");
        if (existing != null) return false;
        
        var identity = new IdentityUser()
        {
            UserName = "Killer01",
            PhoneNumber = "+992987849660",
            Email = "admin@gmail.com"
        };

        var result = await _userManager.CreateAsync(identity, "Admin2001@");
        await _userManager.AddToRoleAsync(identity,"Admin");
        return result.Succeeded;
    }
}