using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.Data.Models
{
    public class Currency{
       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CurrencyCode { get; set; }
        public CurrencyType Type { get; set; }

        public Currency(int id, string currencyCode, CurrencyType type)
        {
            Id = id;
            CurrencyCode = currencyCode;
            Type = type;
        }
    }
}
