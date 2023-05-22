using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoguePalaceAPI.Models;

namespace RoguePalaceAPI.DBContext
{
    public class RoguePalaceDBContext : IdentityDbContext<User, Roles, Guid>
    {
        public RoguePalaceDBContext(DbContextOptions<RoguePalaceDBContext> options) : base(options)
        {

        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Groupe> Groupes { get; set; }

    }
}
