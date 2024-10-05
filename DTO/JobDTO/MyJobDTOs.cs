using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.DTO.JobDTO
{
    public class MyJobDTOs
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? JobTitle { get; set; }
        public string? Location { get; set; }
        public List<string>? JobDescription { get; set; }
        public DateTime StartDate {get;set;}
        public DateTime EndDate {get;set;}
        public bool IsCurrentJob { get; set; } = false;
        public int ResumeId { get; set;}
    }
}