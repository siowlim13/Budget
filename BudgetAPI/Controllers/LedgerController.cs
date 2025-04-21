using System;
using BudgetAPI.Data;
using BudgetAPI.DTOs;
using BudgetAPI.Entities;
using BudgetAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetAPI.Controllers;
//[Authorize]
public class LedgerController(ILedgerRepository ledgerRepository) : BaseApiController
{
    [HttpPost("/AddPayment")]
    public async Task<ActionResult<Ledger>> AddPayments(LedgerDto ledgerDto)
    {
        var payment = await ledgerRepository.AddPaymentAsync(ledgerDto);

        return Ok(payment);
    }
    [HttpGet("{username}")]
    public async Task<ActionResult<IEnumerable<Ledger>>> GetLedger(string username)
    {
        var ledger = await ledgerRepository.GetLedgerAsync(username);

        return Ok(ledger);
    }
}
