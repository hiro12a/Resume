using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.DTO
{
    public class UpdateResumeDTO
    {
        public string? Name {get;set;}
        public string? Summary {get;set;}
        public string? Certification {get;set;}
        public string? Skills {get;set;}
        public DateTime StartDate {get;set;}
        public DateTime EndDate {get;set;}
    }
}