using System;
using BudgetAPI.DTOs;
using BudgetAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BudgetAPI.Controllers;

public class UsersController(IUserRepository userRepository) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RegisterDto>>> GetUsers()
    {
        var accounts = await userRepository.GetUsersAsync();
        
        return Ok(accounts);
    }
}
