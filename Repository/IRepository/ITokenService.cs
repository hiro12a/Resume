using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Resume.Models;

namespace Resume.Repository.IRepository
{
    public interface ITokenService
    {
        // Used to create JWT token 
        string CreateToken(AppUsers user);
    }
}