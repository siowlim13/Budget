namespace BudgetAPI.Entities
{
    public class Ledger
    {
        public int Id { get; set; }
        public decimal Payments { get; set; }
        
        //Navigation properties
        public int AccountId { get; set; }
        public Account Account { get; set; } = null!;

    }
}
