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
        IRequestHandler<UpdateUserCommand, User>,
        IRequestHandler<DeleteUserCommand, User>
    {
        private readonly DatabaseContext _context;

        public UsersCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = new User(request.Login, request.Password, request.Email, request.Role);

            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.Id, cancellationToken);

            if (user == null)
            {
                return null;
            }

            user.Password = request.Password;
            user.Email = request.Email;
            user.Role = request.Role;

            _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);

            return user;
        }

        public async Task<User> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.Id, cancellationToken);

            if (user == null) 
            {
                return null;
            }
                
            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);

            return user;
        }
    }
}
