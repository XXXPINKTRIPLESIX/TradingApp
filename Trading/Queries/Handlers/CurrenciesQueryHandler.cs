using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Trading.Data;
using Trading.Data.Models;
using Trading.Queries.CurrencyQueries;

namespace Trading.Queries.Handlers
{
    public class CurrenciesQueryHandler : 
        IRequestHandler<GetCurrencyQuery, Currency>, 
        IRequestHandler<GetCurrenciesQuery, List<Currency>>
    {
        private readonly DatabaseContext _context;

        public CurrenciesQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Currency> Handle(GetCurrencyQuery request, CancellationToken cancellationToken)
        {
            return await _context.Currencies.FirstOrDefaultAsync(c => c.Id == request.Id);
        }

        public async Task<List<Currency>> Handle(GetCurrenciesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Currencies.ToListAsync();
        }
    }
}
