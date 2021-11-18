using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Trading.Common;
using Trading.Data;
using Trading.Data.Models;
using Trading.DTO.Crypro;
using Trading.DTO.Fiat;
using Trading.Interfaces;
using Trading.Queries.CurrencyQueries;
using Trading.Services;

namespace Trading.Queries.Handlers
{
    public class CurrenciesQueryHandler :
        IRequestHandler<GetCurrencyQuery, Currency>,
        IRequestHandler<GetCurrenciesQuery, List<Currency>>,
        IRequestHandler<GetRatesFiatCurrencyQuery, ExecutionResult>,
        IRequestHandler<GetRatesCryptoCurrencyQuery, ExecutionResult>
    {
        private readonly DatabaseContext _context;
        private readonly FiatCurrencyService _fiatService;
        private readonly CryptoCurrencyService _cryptoService;

        public CurrenciesQueryHandler(DatabaseContext context, IFiatService fiatService, ICryptoService cryptoService)
        {
            _context = context;
            _fiatService = fiatService as FiatCurrencyService;
            _cryptoService = cryptoService as CryptoCurrencyService;
        }

        public async Task<Currency> Handle(GetCurrencyQuery request, CancellationToken cancellationToken)
        {
            return await _context.Currencies.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        }

        public async Task<List<Currency>> Handle(GetCurrenciesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Currencies.ToListAsync(cancellationToken);
        }

        public async Task<ExecutionResult> Handle(GetRatesFiatCurrencyQuery request, CancellationToken cancellationToken)
        {
            return await _fiatService.GatRatesAsync<FiatResponseDTO>(request.BaseCurrency);
        }

        public async Task<ExecutionResult> Handle(GetRatesCryptoCurrencyQuery request, CancellationToken cancellationToken)
        {
            return await _cryptoService.GetRatesAsync<CryptoResponseDTO>(request.BaseCurrency);
        }
    }
}
