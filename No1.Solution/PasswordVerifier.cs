﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No1.Solution
{
    public class PasswordVerifier : IVerifier
    {
        public IdentityResult Verify(string password)
        {
            if (password == null)
                throw new ArgumentException($"{password} is null arg");

            if (password == string.Empty)
                return new IdentityResult(false, new string[] { $"{password} is empty "});

            // check if length more than 7 chars 
            if (password.Length <= 7)
                return new IdentityResult(false, new string[] { $"{password} length too short" });

            // check if length more than 10 chars for admins
            if (password.Length >= 15)
                return new IdentityResult(false, new string[] { $"{password} length too long" });

            // check if password conatins at least one alphabetical character 
            if (!password.Any(char.IsLetter))
                return new IdentityResult(false, new string[] { $"{password} hasn't alphanumerical chars" });

            // check if password conatins at least one digit character 
            if (!password.Any(char.IsNumber))
                return new IdentityResult(false, new string[] { $"{password} hasn't digits" });

            return new IdentityResult(true, new string[]{ "Password is Ok.User was created" });
        }
    }
}
