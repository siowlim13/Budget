namespace BudgetAPI.Entities
{
    public class AccountDetails
    {
        public int AccountDetailsId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime DateCreated { get; set; }
        
        //Navigation properties
        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;
    }
}
