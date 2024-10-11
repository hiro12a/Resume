using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Resume.DTO.JobDTO;

namespace Resume.DTO
{
    public class ResumeDTO
    {
        public int Id { get; set; }
        public string? Name {get;set;}
        public string? Summary {get;set;}
        public string? Certification {get;set;}
        public string? Skills {get;set;}
        // Get the jobs and subtitle
        public List<MyJobDTOs>? JobDTOs {get;set;}
    }
}