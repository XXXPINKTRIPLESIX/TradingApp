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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }

        public PersonalData(int id, string name, string lastname, string surname, string phoneNumber, string description )
        {
            Id = id;
            Name = name;
            LastName = lastname;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Description = description;
        }
    }
}
