﻿using System.ComponentModel.DataAnnotations;

namespace Identity.WebApi.Models
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
