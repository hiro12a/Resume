using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Resume.Helpers;
using Resume.Models;

namespace Resume.Repository.IRepository
{
    public interface IJobRepository
    {
        Task<List<Job>> GetAllAsync(QueryObject query); // returns a query for filtering
        Task<Job?> GetByIdAsync(int id); // QuestionMark makes it optional
        Task<Job> CreateJobAsync(Job jobModel);
        Task<Job?> UpdateJobAsync(int id, Job job);
        Task<Job?> DeleteJobAsync(int id);
    }
}