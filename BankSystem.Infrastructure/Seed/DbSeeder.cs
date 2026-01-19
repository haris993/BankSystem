using BankSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem.Infrastructure.Seed
{
    public static class DbSeeder
    {
        public static IEnumerable<BankAccount> SeedAccounts()
        {
            var list = new List<BankAccount>();
            var rnd = new Random();

            for (int i = 1; i <= 100; i++)
            {
                list.Add(new BankAccount
                {
                    Id = i,
                    AccountNumber = $"ACC-{100000 + i}",
                    IBAN = $"BA39{rnd.Next(100000000, 999999999)}",
                    ClientFirstName = $"Client{i}",
                    ClientLastName = "Test",
                    Email = $"client{i}@bank.com",
                    PhoneNumber = $"+38761{rnd.Next(100000, 999999)}",
                    Balance = rnd.Next(100, 50000),
                    Currency = i % 2 == 0 ? "EUR" : "USD",
                    AccountType = i % 3 == 0 ? "Štedni" : "Tekući",
                    IsActive = i % 4 != 0,
                    CreatedAt = DateTime.UtcNow.AddDays(-i),
                    LastModifiedAt = DateTime.UtcNow,
                    BranchCode = $"BR-{i % 10:D2}",
                    DailyLimit = rnd.Next(500, 5000)
                });
            }

            return list;
        }
    }
}
