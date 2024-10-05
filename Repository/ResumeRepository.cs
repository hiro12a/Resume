using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Resume.Data;
using Resume.DTO;
using Resume.Mapper;
using Resume.Models;
using Resume.Repository.IRepository;

namespace Resume.Repository
{
    public class ResumeRepository : IResumeRepository
    {
        // Dependency injection
        private readonly ApplicationDbContext _db;
        public ResumeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ResumeTemplate> CreateAsync(ResumeTemplate obj)
        {
           // Add data
           await _db.ResumeTemplate.AddAsync(obj);
           await _db.SaveChangesAsync();
           return obj;
        }

        public async Task<ResumeTemplate?> DeleteAsync(int id)
        {
            // Get the data
            var resumeModel = await _db.ResumeTemplate.FirstOrDefaultAsync(x=>x.Id == id);
            if(resumeModel == null)
            {
                return null;
            }

            // Remove the data since it exists
            _db.ResumeTemplate.Remove(resumeModel);
            await _db.SaveChangesAsync();
            return resumeModel;
        }

        public async Task<List<ResumeTemplate>> GetAllAsync()
        {
            // Return all of the data
            return await _db.ResumeTemplate.Include(x=>x.Job).ToListAsync();
        }

        public async Task<ResumeTemplate?> GetByIdAsync(int id)
        {
            // Return the data by its Id
            return await _db.ResumeTemplate.Include(x=>x.Job).FirstOrDefaultAsync(x=>x.Id == id);
        }

        public Task<bool> ResumeExist(int id)
        {
            // Checks if it exist
            return _db.ResumeTemplate.AnyAsync(x=>x.Id == id);
        }

        public async Task<ResumeTemplate?> UpdateAsync(int id, UpdateResumeDTO obj)
        {
            // Find the data by its id
            var resumeModel = await _db.ResumeTemplate.FirstOrDefaultAsync(x=>x.Id == id);
            if(resumeModel == null)
            {
                return null;
            }

            // update each of these
            resumeModel.Name = obj.Name;
            resumeModel.Summary = obj.Summary;
            resumeModel.Skills = obj.Skills;
            resumeModel.Certification = obj.Certification;

            // Save changes
            await _db.SaveChangesAsync();
            return resumeModel;
        }
    }
}