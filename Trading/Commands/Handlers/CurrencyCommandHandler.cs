using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Trading.Commands.CurrencyCommands;
using Trading.Data;
using Trading.Data.Models;
using Trading.DTO.Crypro;
using Trading.DTO.Fiat;
using Trading.Interfaces;
using Trading.Services;

namespace Trading.Commands.Handlers
{
    public class CurrencyCommandHandler :
        IRequestHandler<CreateCurrencyCommand, bool>,
        IRequestHandler<DeleteCurrencyCommand, Currency>,
        IRequestHandler<ExchangeFiatCurrencyCommand, FiatApiResponseDTO>,
        IRequestHandler<ExchangeCryptoCurrencyCommand, CryptoResponseExchangeDTO>
    {
        private readonly DatabaseContext _context;
        private readonly FiatCurrencyService _fiatService;
        private readonly CryptoCurrencyService _cryptoService;

        public CurrencyCommandHandler(DatabaseContext context, IFiatService fiatService, ICryptoService cryptoService)
        {
            _context = context;
            _fiatService = fiatService as FiatCurrencyService;
            _cryptoService = cryptoService as CryptoCurrencyService;
        }

        public async Task<bool> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
        {
            Currency currency = new Currency(request.CurrencyCode, request.Type);

            await _context.Currencies.AddAsync(currency, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<Currency> Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken)
        {
            var currency = await _context.Currencies.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (currency == null)
            {
                return null;
            }

            _context.Currencies.Remove(currency);
            await _context.SaveChangesAsync(cancellationToken);

            return currency;
        }

        public async Task<FiatApiResponseDTO> Handle(ExchangeFiatCurrencyCommand request, CancellationToken cancellationToken)
        {
            return await _fiatService.ExchangeAsync(request.BaseCurrency, request.TargetCurrency, request.Amount);
        }

        public async Task<CryptoResponseExchangeDTO> Handle(ExchangeCryptoCurrencyCommand request, CancellationToken cancellationToken)
        {
            return await _cryptoService.Exchange(request.BaseCurrency, request.TargetCurrency, request.Amount);
        }
    }
}
