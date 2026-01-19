using BankSystem.Application.Queries;
using BankSystem.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountsController : ControllerBase
    {
        private readonly IBankAccountService _service;

        public BankAccountsController(IBankAccountService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] BankAccountQuery query)
        {
            var result = await _service.GetAllAsync(query);
            return Ok(result);
        }
    }
}
