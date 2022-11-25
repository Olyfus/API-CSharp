using Microsoft.EntityFrameworkCore;
using API1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace API1.DBContext
{
    public class SchoolDBContext : IdentityDbContext<User, Roles, Guid>
    {
        public SchoolDBContext(DbContextOptions<SchoolDBContext> options) : base(options)
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
