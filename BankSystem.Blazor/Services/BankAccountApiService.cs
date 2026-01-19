using BankSystem.Blazor.Models;
using System.Net.Http.Json;
using System.Net;
using Microsoft.AspNetCore.WebUtilities;

namespace BankSystem.Blazor.Services
{
    public class BankAccountApiService
    {
        private readonly HttpClient _http;

        public BankAccountApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<PagedResult<BankAccountViewModel>> GetBankAccountsAsync(
            int page = 1,
            int pageSize = 10,
            string? currency = null,
            bool? isActive = null,
            string? search = null)
        {
            page = Math.Max(1, page);
            pageSize = Math.Max(1, pageSize);

            var query = new Dictionary<string, string>
            {
                ["page"] = page.ToString(),
                ["pageSize"] = pageSize.ToString()
            };

            if (!string.IsNullOrWhiteSpace(currency))
                query["currency"] = currency!;
            if (isActive.HasValue)
                query["isActive"] = isActive.Value.ToString().ToLower();
            if (!string.IsNullOrWhiteSpace(search))
                query["search"] = search!;

            // API expects /api/BankAccounts (exact casing as your example)
            var url = QueryHelpers.AddQueryString("api/BankAccounts", query);

            try
            {
                var fullUrl = _http.BaseAddress is null ? url : new Uri(_http.BaseAddress, url).ToString();
                Console.WriteLine($"[BankAccountApiService] GET {fullUrl}");

                using var response = await _http.GetAsync(url);

                Console.WriteLine($"[BankAccountApiService] Response {response.StatusCode} for {fullUrl}");

                if (!response.IsSuccessStatusCode)
                {
                    // log response body for debugging
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"[BankAccountApiService] Body: {body}");
                    return new PagedResult<BankAccountViewModel>();
                }

                var result = await response.Content.ReadFromJsonAsync<PagedResult<BankAccountViewModel>>();
                return result ?? new PagedResult<BankAccountViewModel>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"[BankAccountApiService] HttpRequestException: {ex.Message}");
                // network/server error - return empty result so UI remains responsive
                return new PagedResult<BankAccountViewModel>();
            }
        }
    }
}