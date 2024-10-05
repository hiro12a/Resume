using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql.Replication;
using Resume.DTO;
using Resume.Models;

namespace Resume.Mapper
{
    public static class Mapper
    {
        public static ResumeDTO ToResumeDTO(this ResumeTemplate model)
        {
            return new ResumeDTO
            {
                Id = model.Id, 
                Name = model.Name, 
                Summary = model.Summary,
                Certification = model.Certification,
                Skills = model.Skills, 
                JobDTOs = model.Job.Select(x=>x.ToJobDTO()).ToList(),
            };
        }

        public static ResumeTemplate ToResumeFromCreateDTO(this CreateResumeRequestDTO model)
        {
            return new ResumeTemplate
            {
                Name = model.Name, 
                Summary = model.Summary,
                Certification = model.Certification,
                Skills = model.Skills,
            };
        }
    }
}