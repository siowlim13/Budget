using System;
using BudgetAPI.Data;
using BudgetAPI.DTOs;
using BudgetAPI.Entities;
using BudgetAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BudgetAPI.Controllers;

public class LedgerController(ILedgerRepository ledgerRepository) : BaseApiController
{
    [HttpPost]
    public async Task<ActionResult<Ledger>> AddPayments(LedgerDto ledgerDto)
    {
        var payment = await ledgerRepository.AddPaymentAsync(ledgerDto);

        return Ok(payment);
    }
}
