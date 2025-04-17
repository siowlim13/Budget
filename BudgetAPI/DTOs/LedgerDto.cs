using System;

namespace BudgetAPI.DTOs;

public class LedgerDto
{
    public required string Username { get; set; }
    public decimal Payments { get; set; }
    public required string Category { get; set; }
    public string? Details { get; set; }
    public DateTime DateAdded { get; set; }
}
