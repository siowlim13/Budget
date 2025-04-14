using System;
using BudgetAPI.DTOs;
using BudgetAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BudgetAPI.Data.Repositories;

public class UserRepository(DataContext context) : IUserRepository
{
    public async Task<IEnumerable<RegisterDto>> GetUsersAsync()
    {
        var accounts = await context.Account.ToListAsync();

        var users = new List<RegisterDto> { };
        foreach (var account in accounts)
        {
            var dto = new RegisterDto
            {
                Username = account.Username,
                Password = account.Id.ToString()
            };
            users.Add(dto);
        }
        return users;
    }
}
