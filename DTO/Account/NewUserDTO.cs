using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.DTO.Account
{
    public class NewUserDTO
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Tokens { get; set; }
    }
}