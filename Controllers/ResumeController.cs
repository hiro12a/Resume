using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Resume.Data;
using Resume.DTO;
using Resume.Mapper;
using Resume.Repository.IRepository;

namespace Resume.Controllers
{
    [Route("api/resume")]
    [ApiController]
    public class ResumeController : ControllerBase
    {
        private readonly IResumeRepository _resumeRepo;
        private readonly ILogger<ResumeController> _logger;

        public ResumeController(ILogger<ResumeController> logger, IResumeRepository resumeRepo)
        {
            _resumeRepo = resumeRepo;
            _logger = logger;
        }

        // Return a list
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var resume = await _resumeRepo.GetAllAsync();

            var resumeDTO = resume.Select(u => u.ToResumeDTO());

            return Ok(resume);
        }

        // Return an item by its id
        [HttpGet("{id:int}")] // :int makes sure that the user types in an int instead of a string
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var resume = await _resumeRepo.GetByIdAsync(id);

            if(resume == null)
            {
                return NotFound();
            }

            return Ok(resume.ToResumeDTO());
        }

        // FromBody passes data from http, not from url
        // Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateResumeRequestDTO resumeDTO)
        {
            // Similar to viewmodels, it will only use objects from createresumerequestdto
            // So that users won't be able to manage the Ids and important stuff
            // Get the model data from the mappers
            var resumeModel = resumeDTO.ToResumeFromCreateDTO();
            await _resumeRepo.CreateAsync(resumeModel);

            // Create the object then give  it an id and get its id and return its id
            return CreatedAtAction(nameof(GetById), new {id = resumeModel.Id}, resumeModel.ToResumeDTO());
        }

        // Send data from both the url and body
        // Update
        [HttpPut]
        [Route("{id:int}")] // Specify the Id
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateResumeDTO updateDTO)
        {
            // Find if the resume already exist or not by its Id
            var resumeModel = await _resumeRepo.UpdateAsync(id, updateDTO);
            if(resumeModel == null)
            {
                return NotFound();
            }
            return Ok(resumeModel.ToResumeDTO());
        }

        // Delete
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            // Get the data 
            var resumeModel = await _resumeRepo.DeleteAsync(id);
            if(resumeModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}