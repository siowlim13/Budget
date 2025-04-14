using System;
using BudgetAPI.DTOs;

namespace BudgetAPI.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<RegisterDto>> GetUsersAsync();
}
