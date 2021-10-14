using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;

namespace Trading.Commands.UserCommands
{
    public class UpdatePersonalDataCommand : IRequest<User>
    {
        public int UserId { get; }
        public string Name { get; }
        public string LastName { get; }
        public string Surname { get; }
        public string PhoneNumber { get; }
        public string Description { get; }

        public UpdatePersonalDataCommand(int userId, string name, string lastName, string surname, string phoneNumber, string description)
        {
            UserId = userId;
            Name = name;
            LastName = lastName;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Description = description;
        }
    }
}
