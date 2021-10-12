using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;

namespace Trading.Queries.UserQueries
{
    public class GetUserQuery : IRequest<User>
    {
        public int Id { get; }

        public GetUserQuery(int id)
        {
            Id = id;
        }
    }
}
