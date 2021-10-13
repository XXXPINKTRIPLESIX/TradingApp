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
using Trading.DTO.Response.Fiat;
using Trading.Interfaces;
using Trading.Services;

namespace Trading.Commands.Handlers
{
    public class CurrencyCommandHandler :
        IRequestHandler<CreateCurrencyCommand, bool>,
        IRequestHandler<UpdateCurrencyCommand, Currency>,
        IRequestHandler<DeleteCurrencyCommand, Currency>,
        IRequestHandler<ExchangeCurrencyCommand, CoupledResponseDTO>,
        IRequestHandler<RateCurrencyCommand, CoupledResponseDTO>
    {
        private readonly DatabaseContext _context;
        private readonly FiatCurrencyService _currencyService;

        public CurrencyCommandHandler(DatabaseContext context, IService service)
        {
            _context = context;
            _currencyService = service as FiatCurrencyService;
        }

        public async Task<bool> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
        {
            await _context.Currencies.AddAsync(request.Currency, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<Currency> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
        {
            var currency = await _context.Currencies.FindAsync(request.Currency.Id, cancellationToken);

            if (currency == null)
                return null;

            _context.Currencies.Update(request.Currency);
            await _context.SaveChangesAsync(cancellationToken);

            return await _context.Currencies.FindAsync(currency.Id, cancellationToken);
        }

        public async Task<Currency> Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken)
        {
            var currency = await _context.Currencies.FindAsync(request.Id, cancellationToken);

            if (currency == null)
                return null;

            _context.Currencies.Remove(currency);
            await _context.SaveChangesAsync(cancellationToken);

            return currency;
        }

        public async Task<CoupledResponseDTO> Handle(ExchangeCurrencyCommand request, CancellationToken cancellationToken)
        {
            return await _currencyService.ExchangeAsync(request.RequestDTO);
        }

        public async Task<CoupledResponseDTO> Handle(RateCurrencyCommand request, CancellationToken cancellationToken)
        {
            return await _currencyService.RatesAsync(request.BaseCurrency);
        }
    }
}
