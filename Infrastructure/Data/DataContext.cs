using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext :IdentityDbContext<User>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}

    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<Cart> Carts { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}