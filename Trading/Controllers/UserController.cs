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
        public async Task<List<User>> Get() { return await _userRepository.Get();} 

        [HttpGet("{id}")]
        public async Task<User> Get(int id) { return await _userRepository.Get(id); }

        [HttpGet("/delete/{id}")]
        public async Task<StatusCodeResult> Delete(int id) 
        { 
            await _userRepository.Delete(id);
            return new StatusCodeResult(200);
        }

        [HttpPost]
        public async Task<StatusCodeResult> Add(User user) 
        { 
            await _userRepository.Add(user);
            return new StatusCodeResult(200);
        }

        [HttpPatch]
        public async Task<StatusCodeResult> Update(User user) 
        { 
            await _userRepository.Update(user);
            return new StatusCodeResult(200);
        }
    }
}
