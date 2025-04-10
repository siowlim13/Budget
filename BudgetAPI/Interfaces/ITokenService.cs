using System;
using BudgetAPI.Entities;

namespace BudgetAPI.Interfaces;

public interface ITokenService
{
    string CreateToken(Account account);
}
