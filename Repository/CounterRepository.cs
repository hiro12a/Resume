using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Data;
using Resume.Models;
using Resume.Repository.IRepository;

namespace Resume.Repository
{
    public class CounterRepository : ICounterRepository
    {
        // Inject DBContext
        private readonly ApplicationDbContext _db;
        public CounterRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> GetVisitorCount()
        {
            // Get the value of visitorsCount
            var visitorCount = await _db.VisitorCounter.FirstOrDefaultAsync();
            return visitorCount?.Counter ?? 0; // Return the value and return a 0 if no record exists
        }

        public async Task<int> IncrementVisitorCount()
        {
            // Get the data
            var visitorCount = await _db.VisitorCounter.FirstOrDefaultAsync();

            if(visitorCount == null)
            {
                // Since no record exist, create a new one with a counter value of 1
                visitorCount = new VisitorCounter {Counter = 1};
                _db.VisitorCounter.Add(visitorCount);
            }
            else
            {
                // A record exists, so increment the counter by 1
                visitorCount.Counter++;
            }

            await _db.SaveChangesAsync();
            return visitorCount.Counter;
        }
    }
}