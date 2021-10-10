using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;
using Trading.Interfaces;

namespace Trading.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoneyAccountController : ControllerBase  
    {
        private readonly ILogger<UserController> _logger;
        private readonly IRepository<Account, int> _accountRepository;

        public MoneyAccountController(ILogger<UserController> logger, IRepository<Account, int> accountRepository)
        {
            _logger = logger;
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var res = await _accountRepository.GetAsync();

            if (res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]int id) 
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var res = await _accountRepository.GetAsync(id);

            if (res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Account account) 
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _accountRepository.AddAsync(account);

            return NoContent();
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody]Account account) 
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var res = await _accountRepository.UpdateAsync(account);

            if (res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id) 
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var res = await _accountRepository.DeleteAsync(id);

            if (res == null)
                return NotFound();
            return Ok(res);
        }
    }
}
