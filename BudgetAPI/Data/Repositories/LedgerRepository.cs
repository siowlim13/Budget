using System;
using BudgetAPI.DTOs;
using BudgetAPI.Entities;
using BudgetAPI.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BudgetAPI.Data.Repositories;

public class LedgerRepository(DataContext context) : ILedgerRepository
{
    public async Task<Ledger> AddPaymentAsync(LedgerDto ledgerDto)
    {
        var account = await context.Account.FromSql($"SELECT * FROM Account WHERE Username = {ledgerDto.Username}").FirstOrDefaultAsync();

        if (account == null)
        {
            throw new NotImplementedException("Account does not exist");
        }

        var id = account.Id;

        var payment = new Ledger
        {
            AccountId = id,
            Payments = ledgerDto.Payments,
            Category = ledgerDto.Category,
            Details = ledgerDto.Details,
            DateAdded = ledgerDto.DateAdded
        };

        context.Ledger.Add(payment);
        await context.SaveChangesAsync();

        return payment;
    }

    public async Task<IEnumerable<Ledger>> GetLedgerAsync(string username)
    {
        var account = await context.Account.FromSql($"SELECT * FROM Account WHERE Username = {username}").FirstOrDefaultAsync();

        if (account == null)
        {
            throw new NotImplementedException("Account does not exist");
        }

        var id = account.Id;

        return await context.Ledger.FromSql($"SELECT * FROM Ledger WHERE AccountId = {id}").ToListAsync();
    }
}
