﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.Data.Models
{
    public class User
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string  Email { get; set; }
        public PersonalData PersonalData { get; set; } = null;
        public List<Account> MoneyAccounts { get; set; }

        public User(int id, string login, string password, string email, PersonalData personalData, List<Account> moneyAccounts)
        {
            Id = id;
            Login = login;
            Password = password;
            Email = email;
            MoneyAccounts = moneyAccounts;
            PersonalData = personalData;
        }

        private User() { }
    }
}
