using Domain.DTOs;
using Domain.Response;

namespace Infrastructure.Services;
public interface IOperationService
{
    Task<Response<string>> Payment(PaymentDto model);
    Task<Response<string>> WithDraw(WithDrawDto model);
}
