using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Resume.DTO.JobDTO;
using Resume.Models;

namespace Resume.Mapper
{
    public static class JobMapper
    {
        public static MyJobDTOs ToJobDTO(this Job jobModel)
        {
            return new MyJobDTOs
            {
                Id = jobModel.Id, 
                CompanyName = jobModel.CompanyName,
                JobTitle = jobModel.JobTitle,
                Location = jobModel.Location,
                JobDescription = jobModel.JobDescription,
                StartDate = jobModel.StartDate,
                EndDate = jobModel.EndDate,
                IsCurrentJob = jobModel.IsCurrentJob,
                ResumeId = jobModel.ResumeId  
            };
        }

        public static Job CreateJOB(this CreateJobDTO jobDTO, int resumeId)
        {
            return new Job
            {
                CompanyName = jobDTO.CompanyName,
                JobTitle = jobDTO.JobTitle,
                Location = jobDTO.Location,
                JobDescription = jobDTO.JobDescription,
                StartDate = jobDTO.StartDate,
                IsCurrentJob = jobDTO.IsCurrentJob,
                EndDate = jobDTO.EndDate,
                ResumeId = resumeId // Get the resume id 
            };
        }

        // Create a mapper for updating job
        public static Job UpdateJob(this UpdateJobDTO jobDTO)
        {
            return new Job
            {
                CompanyName = jobDTO.CompanyName,
                JobTitle = jobDTO.JobTitle,
                Location = jobDTO.Location,
                IsCurrentJob = jobDTO.IsCurrentJob,
                JobDescription = jobDTO.JobDescription,
                StartDate = jobDTO.StartDate,
                EndDate = jobDTO.EndDate,
            };
        }
    }
}