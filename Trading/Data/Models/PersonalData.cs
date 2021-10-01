using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.Data.Models
{
    public class PersonalData
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }

        public PersonalData(string name, string lastname, string surname, string phoneNumber, string description )
        {
            Name = name;
            LastName = lastname;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Description = description;
        }

        private PersonalData() { }
    }
}
