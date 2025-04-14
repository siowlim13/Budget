using System.Security.Cryptography;
using System.Text;
using BudgetAPI.Data;
using BudgetAPI.DTOs;
using BudgetAPI.Entities;
using BudgetAPI.Interfaces;
using BudgetAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BudgetAPI.Controllers;

public class AccountController(DataContext context, ITokenService tokenService) : BaseApiController
{
    [HttpPost("register")]
    public async Task<ActionResult<AccountDto>> Register(RegisterDto registerDto)
    {
        if (await UserExists(registerDto.Username)) return BadRequest("Username is taken");
        using var hmac = new HMACSHA512();

        var user = new Account
        {
            Username = registerDto.Username.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt = hmac.Key
        };

        context.Account.Add(user);
        await context.SaveChangesAsync();

        return Ok(new AccountDto
        {
            Username = user.Username,
            Token = tokenService.CreateToken(user)
        });
    }


    private async Task<bool> UserExists(string username)
    {
        return await context.Account.AnyAsync(x => x.Username.ToLower() == username.ToLower());
    }
}