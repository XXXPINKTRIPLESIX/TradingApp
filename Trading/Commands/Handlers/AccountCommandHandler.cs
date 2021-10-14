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
        IRequestHandler<DeleteAccountCommand, Account>
    {
        private readonly DatabaseContext _context;

        public AccountCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            Account account = new Account(request.UserId, request.CurrencyId);

            await _context.Accounts.AddAsync(account, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<Account> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.FindAsync(request.Id, cancellationToken);

            if (account == null) 
            {
                return null;
            }
                
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync(cancellationToken);

            return account;
        }
    }
}
