using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;

namespace Trading.Queries.UserQueries
{
    public class GetUsersQuery : IRequest<List<User>>
    {
    }
}
