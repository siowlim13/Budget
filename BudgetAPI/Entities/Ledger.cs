namespace BudgetAPI.Entities
{
    public class Ledger
    {
        public int Id { get; set; }
        public decimal Income { get; set; }
        
        //Navigation properties
        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;

    }
}
