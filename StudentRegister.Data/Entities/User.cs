using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentRegister.Data.Entities
{
    public class User : IdentityUser
    {
        public string Phone { get; set; }
        public string Token { get; set; }
    }
}
