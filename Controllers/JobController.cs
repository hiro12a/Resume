using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Resume.DTO.JobDTO;
using Resume.Helpers;
using Resume.Mapper;
using Resume.Repository.IRepository;

namespace Resume.Controllers
{
    
    [ApiController]
    [Route("api/job")]
    public class JobController : Controller
    {
        private readonly IJobRepository _job;
        private readonly IResumeRepository _resume;
        public JobController(IJobRepository job, IResumeRepository resume)
        {
            _job = job;
            _resume = resume;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            var jobs = await _job.GetAllAsync(query);

            var sortedJobs = jobs.OrderByDescending(x => x.Id);

            // Turn into DTO/ViewModels
            var jobDTO = sortedJobs.Select(x => x.ToJobDTO());
            
            return Ok(jobs);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromBody] int id)
        {
            // Get the job id
            var job = await _job.GetByIdAsync(id);
            if(job == null)
            {
                return NotFound();
            }

            // Return the job as dto
            return Ok(job.ToJobDTO());
        }

        // Create Job
        [HttpPost]
        [Route("{resumeId:int}")] // Get the resumeId since we want to assocate the job with the resume
        public async Task<IActionResult> Create([FromRoute] int resumeId, CreateJobDTO jobDTO)
        {
            // Makes sure resume exist
            if(!await _resume.ResumeExist(resumeId))
            {
                return BadRequest("Resume does not exist");
            }

            var jobModel = jobDTO.CreateJOB(resumeId);
            await _job.CreateJobAsync(jobModel);

            // Get the Id and return it back into ToJobDTO
            return CreatedAtAction(nameof(GetById), new {id = jobModel.Id}, jobModel.ToJobDTO());
        }

        // Update Job
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateJobDTO jobDTO)
        {
            // Check to make sure the job exist
            var updateJob = await _job.UpdateJobAsync(id, jobDTO.UpdateJob());
            if(updateJob == null)
            {
                return NotFound("Job not found");
            }

            return Ok(updateJob.ToJobDTO());

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var jobModel = await _job.DeleteJobAsync(id);
            if(jobModel == null)
            {
                return NotFound();
            }

            return Ok(jobModel);
        }
    }
}