using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;

namespace Trading.Commands.AccountCommands
{
    public class UpdateAccountCommand : IRequest<Account>
    {
        public int Id { get; }
        public int CurrencyId { get; }
        public int UserId { get; set; }
        public Currency Currency { get; }
        public double Amount { get; }

        public UpdateAccountCommand(int id, int currencyId, int userId, Currency currency, double amount)
        {
            Id = id;
            CurrencyId = currencyId;
            UserId = userId;
            Currency = currency;
            Amount = amount;
        }
    }
}
