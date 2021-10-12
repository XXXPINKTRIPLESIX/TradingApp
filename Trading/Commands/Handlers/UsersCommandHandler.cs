using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Trading.Commands.UserCommands;
using Trading.Data;
using Trading.Data.Models;

namespace Trading.Commands.Handlers
{
    public class UsersCommandHandler :
        IRequestHandler<CreateUserCommand, bool>,
        IRequestHandler<UpdateUserCommand, bool>,
        IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly DatabaseContext _context;

        public UsersCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(request.User, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.User.Id, cancellationToken);

            if (user == null)
                return false;

            _context.Users.Update(request.User);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
