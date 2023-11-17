using Domain.DTOs;
using Domain.Response;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;
[Route("[controller]")]
public class OperationController:ControllerBase
{
    private readonly IOperationService _context;
    public OperationController(IOperationService service) => _context = service;

    [HttpPut("Payment")]
    public async Task<Response<string>> Payment(PaymentDto model)
    {
        return await _context.Payment(model);
    }

    [HttpPut("WithDraw")]
    public async Task<Response<string>> WithDraw(WithDrawDto model) { 
        return await _context.WithDraw(model);
    }
}
