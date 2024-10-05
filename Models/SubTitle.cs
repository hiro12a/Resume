using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Models
{
    public class SubTitle
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int ResumeId { get; set;}
        [ForeignKey(nameof(ResumeId))]
        public ResumeTemplate? ResumeTemplate { get; set; }
    }
}