using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Resume.Data;
using Resume.Helpers;
using Resume.Models;
using Resume.Repository.IRepository;

namespace Resume.Repository
{
    public class JobRepository : IJobRepository
    {
        private readonly ApplicationDbContext _db;             

        public JobRepository(ApplicationDbContext db)
        { 
            _db = db;
        }

        public async Task<Job> CreateJobAsync(Job jobModel)
        {
            await _db.AddAsync(jobModel);
            await _db.SaveChangesAsync();
            return jobModel;
        }

        public async Task<Job?> DeleteJobAsync(int id)
        {
            // Find if job data exist
            var jobModel = await _db.Jobs.FirstOrDefaultAsync(x=>x.Id == id);
            if(jobModel == null)
            {
                return null;
            }

            // Delete job
            _db.Jobs.Remove(jobModel);
            await _db.SaveChangesAsync();
            return jobModel;
        }

        // Use queryobject since we want to be able to filter it 
        public async Task<List<Job>> GetAllAsync(QueryObject query)
        {
            // Filter
            var jobs = _db.Jobs.AsQueryable();
            if(!string.IsNullOrWhiteSpace(query.JobTitle))
            {
                // Filters by name, get the data by jobTitle
                jobs = jobs.Where(x=>x.JobTitle.Contains(query.JobTitle));
            }

            // Sorting
            // Sorting by Job ID in descending order
            jobs = jobs.OrderByDescending(x => x.Id); // Sort by Job ID

            // Adds pagination
            var skipNumber = (query.PageNumber - 1) * query.PageSize; // Always subtract by 1 so it starts at the first page

            // Returns filter and also returns everything in the data
            // if the user did not type in anything
            return await jobs.Skip(skipNumber).Take(query.PageSize).ToListAsync(); // Adds pagination
        }

        public async Task<Job?> GetByIdAsync(int id)
        {
            return await _db.Jobs.FindAsync(id);
        }

        public async Task<Job?> UpdateJobAsync(int id, Job job)
        {
            // Get the current data by its id
            var existingJob = await _db.Jobs.FindAsync(id);
            if (job == null)
            {
                return null;
            }

            // Update each of these
            existingJob.JobTitle = job.JobTitle;
            existingJob.JobDescription = job.JobDescription;
            existingJob.CompanyName = job.CompanyName;
            existingJob.StartDate = job.StartDate;
            existingJob.EndDate = job.EndDate;
            existingJob.Location = job.Location;
            existingJob.IsCurrentJob = job.IsCurrentJob;

            await _db.SaveChangesAsync();

            return existingJob;
        }
    }
}