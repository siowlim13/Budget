using System;

namespace BudgetAPI.DTOs;

public class AccountDto
{
    public required string Username { get; set; }
    public required string Token { get; set; }
}
