using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.Data.Models
{
    public static class DefaultDataProvider
    {
        public static List<User> GetUsers()
        {
            //List<Account> accounts = new List<Account>()
            //{
            //    new Account()
            //};

            return new List<User>
            {
                new User(1, "111", "111", "111@gmail.com", "admin"),
                new User(2, "222", "222", "222@gmail.com", "user"),
                new User(3, "333", "333", "333@gmail.com", "user"),
                new User(4, "444", "444", "444@gmail.com", "user"),
                new User(5, "555", "555", "555@gmail.com", "user"),
                new User(6, "666", "666", "666@gmail.com", "user")
            };
        }

        public static List<Currency> GetCurrencies()
        {
            return new List<Currency>
            {
                new Currency(1, "USD", CurrencyType.Fiat),
                new Currency(2, "EUR", CurrencyType.Fiat),
                new Currency(3, "UAH", CurrencyType.Fiat),
                new Currency(4, "RUB", CurrencyType.Fiat),
                new Currency(5, "CNY", CurrencyType.Fiat),
                new Currency(6, "GBP", CurrencyType.Fiat),

                new Currency(7, "USDT", CurrencyType.Crypto),
                new Currency(8, "ADA", CurrencyType.Crypto),
                new Currency(9, "BNB", CurrencyType.Crypto),
                new Currency(10, "XRP", CurrencyType.Crypto),
                new Currency(11, "SOL", CurrencyType.Crypto),
                new Currency(12, "USDC", CurrencyType.Crypto),

            };
        }
    }
}


