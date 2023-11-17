using Domain.Response;

namespace Infrastructure.Services.WalletServices;

public interface IWalletService
{
    Task<Response<string>> CheckWallet(string phoneNumber);
}