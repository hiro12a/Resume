using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Resume.DTO;
using Resume.Models;

namespace Resume.Repository.IRepository
{
    public interface IResumeRepository
    {
        // Gives us a list of all the created resume
        Task<List<ResumeTemplate>> GetAllAsync();
        // Get data by its id
        Task<ResumeTemplate?> GetByIdAsync(int id); // The question marks tells us that it can be null
        // Create the data
        Task<ResumeTemplate> CreateAsync(ResumeTemplate obj); 
        // Update the data
        // Get the id and we want to use the DTOs(Viewmodels)
        Task<ResumeTemplate?>  UpdateAsync(int id, UpdateResumeDTO obj);
        // Delete the data
        Task<ResumeTemplate?> DeleteAsync(int id);

        // To Check if the resume exist
        Task<bool> ResumeExist(int id);
    }
}