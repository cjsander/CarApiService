namespace CarApi.Data
{
    public class CarProcessor
    {
        private readonly CarsDbContext db;

        public CarProcessor(CarsDbContext db)
        {
            // The dependency injection is cruical. This allows us to
            // easily switch between InMemory and actual databases.
            this.db = db;
        }
    }
}
