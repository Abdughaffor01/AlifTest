using Domain.DTOs.IdentifiedDTOs;
using Domain.Response;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;
[Route("[controller]")]
[Authorize]
public class IdentifiedController:ControllerBase
{
    private readonly IIdentifiedService _service;
    public IdentifiedController(IIdentifiedService service)=>_service = service;


    [HttpGet("GetUnIdentified")]
    public async Task<Response<List<GetIdentifiedDto>>> GetUnIdentified()
    {
        return await _service.GetUnIdentifiedRequest();
    }

    [HttpPut("AddIdentifiedToOwner")]
    public async Task<Response<string>> AddIdentifiedToOwner(string phoneNumber)
    {
        return await _service.AddIdentifiedToUser(phoneNumber);
    }
}
