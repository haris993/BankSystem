

namespace BankSystem.Application.Dtos
{
    public class BankAccountDto
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string ClientName { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public bool IsActive { get; set; }
        public string AccountType { get; set; }
    }
}
