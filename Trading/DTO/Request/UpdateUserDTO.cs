using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.DTO.Request
{
    public class UpdateUserDTO
    {
        public int Id { get; }
        public string Password { get; }
        public string Email { get; }
        public string Role { get; }
    }
}
