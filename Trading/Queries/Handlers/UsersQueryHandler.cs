using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Trading.Data;
using Trading.Data.Models;
using Trading.Queries.UserQueries;

namespace Trading.Queries.Handlers
{
    public class UsersQueryHandler : 
        IRequestHandler<GetUserQuery, User>, 
        IRequestHandler<GetUsersQuery, List<User>>
    {
        private readonly DatabaseContext _context;

        public UsersQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == request.Id);
        }

        public async Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.ToListAsync();
        }
    }
}
