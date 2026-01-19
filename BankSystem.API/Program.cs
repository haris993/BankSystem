using BankSystem.Application.Profiles;
using BankSystem.Application.Repositories.Definitions;
using BankSystem.Application.Repositories.Interfaces;
using BankSystem.Application.Services.Definitions;
using BankSystem.Application.Services.Interfaces;
using BankSystem.Infrastructure.Data;
using BankSystem.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Fix CS8604 by providing a non-null database name for the in-memory database.
// If the connection string is null, use a default name "BankDb".
builder.Services.AddDbContext<BankDbContext>(opt =>
{
    var dbName = builder.Configuration.GetConnectionString("BankDb") ?? "BankDb";
    opt.UseInMemoryDatabase(dbName);
});

builder.Services.AddScoped<IBankAccountRepository, BankAccountRepository>();
builder.Services.AddScoped<IBankAccountService, BankAccountService>();

builder.Services.AddAutoMapper(cfg => { }, typeof(BankAccountProfile));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BankDbContext>();

    if (!context.BankAccounts.Any())
    {
        context.BankAccounts.AddRange(DbSeeder.SeedAccounts());
        context.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
