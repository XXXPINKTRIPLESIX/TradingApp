using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;

namespace Trading.Queries.CurrencyQueries
{
    public class GetCurrencyQuery : IRequest<Currency>
    {
        public int Id { get; }

        public GetCurrencyQuery(int id)
        {
            Id = id;
        }
    }
}
