using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;

namespace Trading.Queries.AccountQueries
{
    public class GetAccountQuery : IRequest<Account>
    {
        public int Id { get; set; }
    }
}
