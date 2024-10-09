using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Repository.IRepository
{
    public interface ICounterRepository
    {
        Task<int> GetVisitorCount();
        Task<int> IncrementVisitorCount();
    }
}