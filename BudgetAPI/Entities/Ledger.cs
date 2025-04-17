using System.Text.Json.Serialization;

namespace BudgetAPI.Entities
{
    public class Ledger
    {
        public int Id { get; set; }
        public decimal Payments { get; set; }
        public string Category { get; set; } = string.Empty;
        public string? Details { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        
        //Navigation properties
        public int AccountId { get; set; }
        [JsonIgnore]
        public Account Account { get; set; } = null!;

    }
}
