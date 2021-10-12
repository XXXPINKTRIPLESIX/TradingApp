using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;

namespace Trading.Queries.CurrencyQueries
{
    public class GetCurrenciesQuery : IRequest<List<Currency>>
    {
    }
}
