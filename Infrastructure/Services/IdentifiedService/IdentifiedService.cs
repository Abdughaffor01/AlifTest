using System.Net;
using Domain.DTOs.IdentifiedDTOs;
using Domain.Entities;
using Domain.Enums;
using Domain.Response;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.IdentifiedService;
public class IdentifiedService : IIdentifiedService
{
    private readonly DataContext _context;
    private readonly UserManager<User> _userManager; 
    public IdentifiedService(DataContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }


    public async  Task<Response<string>> AddIdentifiedToUser(string phoneNumber)
    {
        try
        {
            var user = await _userManager.Users.Where(o => o.FirstName != null & o.LastName != null)
                .FirstOrDefaultAsync(o=>o.PhoneNumber== phoneNumber);
            if (user == null) return new Response<string>(HttpStatusCode.NotFound,"not found user");
            user.StatusUser = StatusUser.Identified;
            await _context.SaveChangesAsync();
            return new Response<string>("Successfully identified user");

        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<List<GetIdentifiedDto>>> GetUnIdentifiedRequest()
    {
        var users = await _userManager.Users
            .Where(o =>o.StatusUser==StatusUser.Unidentified).ToListAsync();
        if (users.Count == 0) return new Response<List<GetIdentifiedDto>>(HttpStatusCode.NotFound,"no request");
        var ownersMapped= new List<GetIdentifiedDto>();
        foreach (var o in users)
        {
            var owner = new GetIdentifiedDto()
            {
                FirstName = o.FirstName,
                LastName = o.FirstName,
                PhoneNumber = o.PhoneNumber,
                Status = o.StatusUser.ToString(),
            };
            ownersMapped.Add(owner);
        }
        return new Response<List<GetIdentifiedDto>>(ownersMapped);
    }
}
