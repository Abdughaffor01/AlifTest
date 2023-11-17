using Domain.DTOs.TransactionDTOs;
using Domain.Response;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;
[Route("[controller]")]
[Authorize]
public class TransactionController:ControllerBase
{
    private readonly ITransactionService _service;
    public TransactionController(ITransactionService service)=>_service = service;

    [HttpPost("AddTransactionAsync")]
    public async Task<Response<GetTransactionDto>> AddTransactionAsync(AddTransactionDto model) { 
        return await _service.AddTransactionAsync(model);
    }

    [HttpGet("GetTransactionsAsync")]
    public async Task<Response<List<GetTransitionByNumber>>> GetTransactionsAsync() { 
        var phoneNumber = User.Claims.FirstOrDefault(x => x.Type == "iss")!.Value;
        return await _service.GetTransactionsAsync(phoneNumber);
    }
}
