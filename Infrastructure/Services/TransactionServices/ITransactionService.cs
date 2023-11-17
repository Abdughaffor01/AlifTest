using Domain.DTOs.TransactionDTOs;
using Domain.Response;

namespace Infrastructure.Services;
public interface ITransactionService
{
    Task<Response<List<GetTransitionByNumber>>> GetTransactionsAsync(string phoneNumber);
    Task<Response<GetTransactionDto>> AddTransactionAsync(AddTransactionDto model);
}
