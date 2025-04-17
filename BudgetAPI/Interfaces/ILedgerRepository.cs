using System;
using BudgetAPI.DTOs;
using BudgetAPI.Entities;

namespace BudgetAPI.Interfaces;

public interface ILedgerRepository
{
    Task<Ledger> AddPaymentAsync(LedgerDto ledgerDto);
    Task<Ledger> GetPaymentsAsync();
}
