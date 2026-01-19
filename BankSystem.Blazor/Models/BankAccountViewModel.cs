namespace BankSystem.Blazor.Models
{
    public class BankAccountViewModel
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public string Currency { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string AccountType { get; set; } = string.Empty;
    }
}
