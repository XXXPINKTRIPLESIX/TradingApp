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

            var users = await _userRepository.GetAsync();

            if (users == null)
                return NotFound();
            return Ok(users);
        } 

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userRepository.GetAsync(id);

            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpDelete("/delete/{id}")]
        public async Task<IActionResult> Delete(int id) 
        { 
            await _userRepository.DeleteAsync(id);
            return new StatusCodeResult(200);
        }

        [HttpPost]
        public async Task<StatusCodeResult> Add(User user) 
        { 
            await _userRepository.AddAsync(user);
            return new StatusCodeResult(200);
        }

        [HttpPatch]
        public async Task<StatusCodeResult> Update(User user) 
        { 
            await _userRepository.UpdateAsync(user);
            return new StatusCodeResult(200);
        }
    }
}
