using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Models
{
    public class Job
    {
        public int Id { get; set; }
        [Required]
        public string? CompanyName { get; set; }
        [Required]
        public string? JobTitle { get; set; }
        [Required]
        public string? Location { get; set; }
        [Required]
        public List<string>? JobDescription { get; set; }
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy hh:mm tt}")]
        public DateTime StartDate {get;set;}
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy hh:mm tt}")]
        public DateTime EndDate {get;set;}

        // For current job
        public bool IsCurrentJob { get; set; } = false;

        public int ResumeId { get; set; }
        [ForeignKey(nameof(ResumeId))]
        public ResumeTemplate? ResumeTemplate { get; set; }
    }
}