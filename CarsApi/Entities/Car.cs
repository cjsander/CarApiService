using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CarApi.Entities
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
        public int Year { get; set; }
    }

}
