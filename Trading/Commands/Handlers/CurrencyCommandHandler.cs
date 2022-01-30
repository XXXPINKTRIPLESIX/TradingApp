using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Trading.Commands.CurrencyCommands;
using Trading.Common;
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
        IRequestHandler<ExchangeFiatCurrencyCommand, ExecutionResult>,
        IRequestHandler<ExchangeCryptoCurrencyCommand, ExecutionResult>
    {
        private readonly DatabaseContext _context;
        private readonly IFiatService _fiatService;
        private readonly ICryptoService _cryptoService;

        public CurrencyCommandHandler(DatabaseContext context, IFiatService fiatService, ICryptoService cryptoService) =>
            (_context, _fiatService, _cryptoService) = (context, fiatService, cryptoService);

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

        public async Task<ExecutionResult> Handle(ExchangeFiatCurrencyCommand request, CancellationToken cancellationToken)
        {
            Account account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == request.AccountId);
            Account targetAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == request.TargetAccountId);

            if(account.UserId != targetAccount.UserId) 
            {
                throw new NotImplementedException();
            }

            if(account.Currency.Type != CurrencyType.Fiat &&  targetAccount.Currency.Type != CurrencyType.Fiat) 
            {
                throw new NotImplementedException();
            }

            if(account.Amount < request.Amount) 
            {
                throw new NotImplementedException();
            }

            account.Amount -= request.Amount;

            var result = await ExchangeFiat(account.Currency.CurrencyCode, targetAccount.Currency.CurrencyCode, request.Amount) as ExecutionResult<FiatResponseDTO>;

            if(result.Error == null) 
            {
                throw new NotImplementedException();
            }

            targetAccount.Amount += result.Result.ConversionResult;

            throw new NotImplementedException(); 
        }

        public async Task<ExecutionResult> Handle(ExchangeCryptoCurrencyCommand request, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == request.AccountId);
            var targetAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == request.TargetAccountId);

            if (account.UserId != targetAccount.UserId)
            {
                throw new NotImplementedException();
            }

            //if (account.Currency.Type != CurrencyType.Fiat && targetAccount.Currency.Type != CurrencyType.Fiat)
            //{
            //    throw new NotImplementedException();
            //}

            if (account.Amount < request.Amount)
            {
                return ExecutionResult.CreateError($"{account.Amount} less than {request.Amount}");
            }

            var response = await ExchangeCrypto(account.Currency.CurrencyCode, targetAccount.Currency.CurrencyCode, request.Amount) as ExecutionResult<CryptoResponseDTO>;

            account.Amount -= request.Amount;

            if (response.IsSuccess == false)
            {
                return response;
            }

            targetAccount.Amount += response.Result.Rate;

            throw new NotImplementedException();
        }

        private async Task<ExecutionResult> ExchangeFiat(string baseCurrency, string targetCurrency, double amount) 
        {
            return await _fiatService.ExchangeAsync(baseCurrency, targetCurrency, amount);
        }

        private async Task<ExecutionResult> ExchangeCrypto(string baseCurrency, string targetCurrency, double amount)
        {
            return await _cryptoService.ExchangeAsync(baseCurrency, targetCurrency, amount);
        }
    }
}
