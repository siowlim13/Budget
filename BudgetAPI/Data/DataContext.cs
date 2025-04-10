using BudgetAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BudgetAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Account> Account { get; set; }
        public DbSet<AccountDetails> AccountDetails { get; set; }
        public DbSet<Ledger> Ledger { get; set; }
    }
}
