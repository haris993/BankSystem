
namespace BankSystem.Domain.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string IBAN { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public string AccountType { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public string BranchCode { get; set; }
        public decimal DailyLimit { get; set; }
    }
}
