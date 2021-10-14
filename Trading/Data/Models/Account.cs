using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.Data.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public int UserId { get; set; }
        public Currency Currency { get; set; }
        public double Amount { get; set; }

        public Account(int  userId, int currencyId)
        {
            UserId = userId;
            CurrencyId = currencyId;
        }

        private Account() { }
    }
}
