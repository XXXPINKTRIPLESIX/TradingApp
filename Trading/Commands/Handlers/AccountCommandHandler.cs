using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Trading.Commands.AccountCommands;
using Trading.Data;

namespace Trading.Commands.Handlers
{
    public class AccountCommandHandler :
        IRequestHandler<CreateAccountCommand, bool>,
        IRequestHandler<UpdateAccountCommand, bool>,
        IRequestHandler<DeleteAccountCommand, bool>
    {
        private readonly DatabaseContext _context;

        public AccountCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            await _context.Accounts.AddAsync(request.Account, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == request.Account.Id, cancellationToken);

            if (account == null)
                return false;

            _context.Accounts.Update(request.Account);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            if (account == null)
                return false;

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
