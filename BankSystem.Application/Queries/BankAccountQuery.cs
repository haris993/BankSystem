namespace BankSystem.Application.Queries
{
    public class BankAccountQuery
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Currency { get; set; }
        public bool? IsActive { get; set; }
        public string? Search { get; set; }
    }
}
