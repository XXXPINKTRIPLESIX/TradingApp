﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading.Utils
{
    public static class UserUtils
    {
        public static string EncryptPassword(string password)
        {
            var data = Encoding.ASCII.GetBytes(password);

            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);

            string hash = Encoding.ASCII.GetString(data);

            var hashBytes = Encoding.UTF8.GetBytes(hash);

            return Convert.ToBase64String(hashBytes);
        }
    }
}
