namespace BudgetAPI.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public byte[] PasswordHash { get; set; } = [];
        public byte[] PasswordSalt { get; set; } = [];
        public AccountDetails? AccountDetails { get; set; }
        public List<Ledger>? Ledger { get; set; }
    }
}
