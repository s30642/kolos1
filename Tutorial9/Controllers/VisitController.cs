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
        public async Task<IActionResult> GetCustomerRentals(int id)
        {
            try
            {
                var res = await _dbService.DoSomethingAsync(id);
                return Ok(res);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("{id}/rentals")]
        public async Task<IActionResult> AddNewRental(int id, CreateRentalRequestDto createRentalRequest)
        {
            if (!createRentalRequest.Movies.Any())
            {
                return BadRequest("At least one item is required.");
            }

            try
            {
                await _dbService.AddNewRentalAsync(id, createRentalRequest);
            }
            catch (ConflictException e)
            {
                return Conflict(e.Message);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            
            return CreatedAtAction(nameof(GetCustomerRentals), new { id }, createRentalRequest);
        }    
    }
}
