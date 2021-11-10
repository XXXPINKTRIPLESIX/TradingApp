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
        IRequestHandler<ExchangeFiatCurrencyCommand, ExecutionResult<Account>>,
        IRequestHandler<ExchangeCryptoCurrencyCommand, ExecutionResult<Account>>
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

        public async Task<ExecutionResult<Account>> Handle(ExchangeFiatCurrencyCommand request, CancellationToken cancellationToken)
        {
            Account account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == request.AccountId, cancellationToken);
            Account targetAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == request.TargetAccountId, cancellationToken);

            if(account.UserId != targetAccount.UserId)
            {
                return ExecutionResult<Account>.CreateErrorResult("Accounts belongs to different user.");
            }

            if(account.Currency.Type != CurrencyType.Fiat &&  targetAccount.Currency.Type != CurrencyType.Fiat)
            {
                return ExecutionResult<Account>.CreateErrorResult("Wrong currency type.");
            }

            if(account.Amount < request.Amount)
            {
                return ExecutionResult<Account>.CreateErrorResult("Not enough currency amount to convert.");
            }

            var result = await ExchangeFiat<FiatResponseDTO>(account.Currency.CurrencyCode, targetAccount.Currency.CurrencyCode, request.Amount);

            if(!result.IsSuccess)
            {
                return ExecutionResult<Account>.CreateErrorResult($"{result.Error}");
            }
            
            account.Amount -= request.Amount;
            targetAccount.Amount += result.Result.ConversionResult;
            await _context.SaveChangesAsync(cancellationToken);

            return ExecutionResult<Account>.CreateSuccessResult(targetAccount); 
        }

        public async Task<ExecutionResult<Account>> Handle(ExchangeCryptoCurrencyCommand request, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == request.AccountId, cancellationToken);
            var targetAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == request.TargetAccountId, cancellationToken);
            
            if (account.UserId != targetAccount.UserId)
            {
                return ExecutionResult<Account>.CreateErrorResult("Accounts belongs to different user.");
            }
            
            var currencies = await _context.Currencies.Where(c => c.Type == CurrencyType.Fiat).ToListAsync(cancellationToken);
            //
            //NEED TO CHECK FOR SUPPORTED CURRENCIES(FIAT (IF FIAT)) TO CONVERT TO CRYPTO!
            //
            
            if (account.Amount < request.Amount)
            {
                return ExecutionResult<Account>.CreateErrorResult("Not enough currency amount to convert.");
            }

            var response = await ExchangeCrypto<CryptoResponseDTO>(account.Currency.CurrencyCode, targetAccount.Currency.CurrencyCode, request.Amount);

            if (!response.IsSuccess)
            {
                return ExecutionResult<Account>.CreateErrorResult($"{response.Error}");
            }
            
            account.Amount -= request.Amount;
            targetAccount.Amount += response.Result.Rate;
            await _context.SaveChangesAsync(cancellationToken);
            
            return ExecutionResult<Account>.CreateSuccessResult(targetAccount);
        }

        private async Task<ExecutionResult<T>> ExchangeFiat<T>(string baseCurrency, string targetCurrency, double amount) 
        {
            return await _fiatService.ExchangeAsync<T>(baseCurrency, targetCurrency, amount);
        }

        private async Task<ExecutionResult<T>> ExchangeCrypto<T>(string baseCurrency, string targetCurrency, double amount)
        {
            return await _cryptoService.ExchangeAsync<T>(baseCurrency, targetCurrency, amount);
        }
    }
}
