using CarApi.Controllers;
using CarApi.Data;
using CarApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarApiTest
{
    [TestFixture]
    public class CarDbContextUnitTests
    {
        private CarsDbContext? _context;
        private CreateCarService? _createCarService;

        [SetUp]
        public void Setup()
        {
            var dbContextOptions = new DbContextOptionsBuilder<CarsDbContext>().UseInMemoryDatabase("CarsListDbTest");
            _context = new CarsDbContext(dbContextOptions.Options);
            _context.Database.EnsureCreated();

            _createCarService = new CreateCarService(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
        }

        [Test]
        public async Task AddNewCar_Valid()
        {
            var newCar = new Car
            {
                Name = "Porsche 911 Carrera S",
                Color = "Red",
                Year = 2019
            };

            var entityId = await _createCarService.CreateCar(newCar);
            var car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == entityId);
            Assert.That(car, Is.Not.Null);
            Assert.That(car.Name, Is.EqualTo(newCar.Name));
        }
    }
}