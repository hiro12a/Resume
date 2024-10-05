using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Helpers
{
    // This is used for filtering and quick search
    public class QueryObject
    {
        // Will search by jobtitle
        // Filter
        public string? JobTitle { get; set;}

        // Sorting
        public string? SortBy { get; set; } 
        public bool IsDescending {get;set;}

        // Pagination
        public int PageNumber {get;set;} = 1; 
        public int PageSize {get;set;} = 20;
    }
}