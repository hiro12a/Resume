using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Resume.Repository.IRepository;

namespace Resume.Controllers
{
    [Route("api/visitor")]
    [ApiController]
    public class VisitorCounterController : Controller
    {
        // Dependency injection so we can use the repositories
        private readonly ICounterRepository _counter;
        public VisitorCounterController(ICounterRepository counter)
        {
            _counter = counter;
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetVisitor()
        {
            var visitorCount = await _counter.GetVisitorCount();
            return Ok(visitorCount);
        }

        [HttpPost("increment")]
        public async Task<IActionResult> IncrementVisitor()
        {
            await _counter.IncrementVisitorCount();
            return Ok(new {message = "Visitor Count Incremented Successfully"});
        }
    }
}