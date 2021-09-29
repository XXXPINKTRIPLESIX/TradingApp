using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.Data.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public PersonalData PersonalData { get; set; }
        public List<Balance> Balances { get; set; }

        public User(int id, PersonalData personalData, List<Balance> balances)
        {
            Id = id;
            PersonalData = personalData;
            Balances = balances;
        }
    }
}
