﻿using MediatR;
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
<<<<<<< HEAD
        private readonly IFiatService _fiatService;
        private readonly ICryptoService _cryptoService;

        public CurrenciesQueryHandler(DatabaseContext context, IFiatService fiatService, ICryptoService cryptoService) =>
            (_context, _cryptoService, _fiatService) = (context, cryptoService, fiatService);

        public async Task<Currency> Handle(GetCurrencyQuery request, CancellationToken cancellationToken) =>
             await _context.Currencies.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        

        public async Task<List<Currency>> Handle(GetCurrenciesQuery request, CancellationToken cancellationToken) =>
             await _context.Currencies.ToListAsync(cancellationToken);
        

        public async Task<ExecutionResult> Handle(GetRatesFiatCurrencyQuery request, CancellationToken cancellationToken) =>
             await _fiatService.GatRatesAsync(request.BaseCurrency);


        public async Task<ExecutionResult> Handle(GetRatesCryptoCurrencyQuery request, CancellationToken cancellationToken) =>
             await _cryptoService.GetRatesAsync(request.BaseCurrency);

=======
        private readonly ICurrencyService<FiatResponseDTO> _fiatService;
        private readonly ICurrencyService<CryptoResponseDTO> _cryptoService;

        public CurrenciesQueryHandler(DatabaseContext context, ICurrencyService<FiatResponseDTO> fiatService, ICurrencyService<CryptoResponseDTO> cryptoService)
        {
            _context = context;
            _fiatService = fiatService;
            _cryptoService = cryptoService;
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
            return await _fiatService.GetRatesAsync<FiatResponseDTO>(request.BaseCurrency);
        }

        public async Task<ExecutionResult> Handle(GetRatesCryptoCurrencyQuery request, CancellationToken cancellationToken)
        {
            return await _cryptoService.GetRatesAsync<CryptoResponseDTO>(request.BaseCurrency);
        }
>>>>>>> 49fbae1b169b8d35e3920b48a9599495e5d661a6
    }
}
