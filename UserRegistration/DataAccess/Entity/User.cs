﻿using FluentValidation;
using System.Text.RegularExpressions;

namespace UserRegistration.DataAccess.Entity
{
    public class User
    {
        public string FullName { get; set; }
        public string UserName { get; set; }  
        public string Password { get; set; }  
        public string Email { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; } 

    }
}
