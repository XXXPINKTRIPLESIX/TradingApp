using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Trading.Data;
using Trading.Data.Models;
using Trading.Queries.AccountQueries;

namespace Trading.Queries.Handlers
{
    public class AccountsQueryHandler : 
        IRequestHandler<GetAccountQuery, Account>, 
        IRequestHandler<GetAccountsQuery, List<Account>>
    {
        private readonly DatabaseContext _context;

        public AccountsQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Account> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            return await _context.Accounts.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        }

        public async Task<List<Account>> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Accounts.ToListAsync(cancellationToken);
        }
    }
}
