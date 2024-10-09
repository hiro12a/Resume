using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Models
{
    public class ResumeTemplate
    {
        public int Id { get; set; }
        public string? Name {get;set;}
        [DisplayName("Professional Summary")]
        public string? Summary {get;set;}
        public string? Certification {get;set;}
        public string? Skills {get;set;}
        public List<Job>? Job {get;set;}
    }
}