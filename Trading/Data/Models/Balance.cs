using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.Data.Models
{
    public class Balance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public double Amount { get; set; }

        public Balance(int  id, int currencyId, /*Currency currency,*/ double amount)
        {
            Id = id;
            CurrencyId = currencyId;
            //Currency = currency;
            Amount = amount;
        }
        
    }
}
