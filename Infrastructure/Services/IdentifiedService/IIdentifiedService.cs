using Domain.DTOs.IdentifiedDTOs;
using Domain.Response;

namespace Infrastructure.Services;
public interface IIdentifiedService
{
    Task<Response<string>> AddIdentifiedToUser(string phoneNumber);
    Task<Response<List<GetIdentifiedDto>>> GetUnIdentifiedRequest();
}
