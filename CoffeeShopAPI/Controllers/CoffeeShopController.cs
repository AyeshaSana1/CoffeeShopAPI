using CoffeeShopAPI.DAL;
using CoffeeShopAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoffeeShopController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoffeeShopController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCoffeeShop([FromBody] CoffeeShop coffeeShop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CoffeeShops.Add(coffeeShop);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCoffeeShop), new { id = coffeeShop.Id }, coffeeShop);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoffeeShop(int id)
        {
            var coffeeShop = await _context.CoffeeShops.FindAsync(id);
            if (coffeeShop == null)
            {
                return NotFound();
            }
            return Ok(coffeeShop);
        }
    }
}
