using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Trading.Commands.AccountCommands;
using Trading.Data;
using Trading.Data.Models;

namespace Trading.Commands.Handlers
{
    public class AccountCommandHandler :
        IRequestHandler<CreateAccountCommand, bool>,
        IRequestHandler<UpdateAccountCommand, Account>,
        IRequestHandler<DeleteAccountCommand, Account>
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

        public async Task<Account> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.FindAsync(request.Account.Id, cancellationToken);

            if (account == null)
                return null;

            _context.Accounts.Update(request.Account);
            await _context.SaveChangesAsync(cancellationToken);

            return await _context.Accounts.FindAsync(account.Id, cancellationToken);
        }

        public async Task<Account> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.FindAsync(request.Id, cancellationToken);

            if (account == null)
                return null;

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync(cancellationToken);

            return account;
        }
    }
}
