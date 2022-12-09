using Microsoft.EntityFrameworkCore;
using RoguePalaceAPI.Models;

namespace RoguePalaceAPI.DBContext
{
    public class RoguePalaceDBContext : DbContext
    {
        public RoguePalaceDBContext(DbContextOptions<RoguePalaceDBContext> options) : base(options)
        {

        }
        public DbSet<Character> Characters { get; set; }
    }
}
