using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;
using Trading.Interfaces.Database;

namespace Trading.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IRepository<User, int> _userRepository;
        
        public UserController(ILogger<UserController> logger, IRepository<User, int> userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }
        public async Task<IActionResult> Get() 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _userRepository.GetAsync();

            if (res == null)
                return NotFound();
            return Ok(res);
        } 

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _userRepository.GetAsync(id);

            if (res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpDelete("/delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _userRepository.DeleteAsync(id);

            if (res == null)
                return NotFound();

            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] User user) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userRepository.AddAsync(user);

            return NoContent();
        }

        [HttpPatch]
        public async Task<IActionResult> Update(User user) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var res = await _userRepository.UpdateAsync(user);

            if (res == null)
                return NotFound();

            return Ok(res);
        }
    }
}
