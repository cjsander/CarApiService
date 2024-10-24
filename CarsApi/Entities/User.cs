using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CarApi.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
    }
}
