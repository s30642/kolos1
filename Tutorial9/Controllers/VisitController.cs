//using Tutorial9.Exceptions;
using Tutorial9.Model;
using Tutorial9.Services;
using Microsoft.AspNetCore.Mvc;

namespace Tutorial9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly IDbService _dbService;
        public VisitController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVisit(int id)
        {
        
            var res = await _dbService.DoSomethingAsync(id);
            return Ok(res);
         
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewVisit()
        {
            _dbService.DoSomethingAsync1(id, createRentalRequest);           
        }    
    }
}
