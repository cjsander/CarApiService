using CarApi.Data;
using CarApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarsDbContext _context;

        public CarsController(CarsDbContext context)
        {
            _context = context;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            return await _context.Cars.ToListAsync();
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // POST: api/Cars
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }

    public class CreateCarService
    {
        private readonly CarsDbContext _context;

        public CreateCarService(CarsDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateCar(Car car)
        {
            var newCar = new Car
            {
                Id = car.Id,
                Name = car.Name,
                Color = car.Color,
                Year = car.Year
            };

            var entity = await _context.Cars.AddAsync(newCar);
            await _context.SaveChangesAsync();
            return entity.Entity.Id;

        }

    }
}
