using RoguePalaceAPI.DBContext;
using RoguePalaceAPI.Dto.User;
using RoguePalaceAPI.Models;

namespace RoguePalaceAPI.Repositories
{
    public class UserRepositories : IUserRepositories
    {
        private readonly RoguePalaceDBContext _dbContext;
        public UserRepositories(RoguePalaceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User GetUserByName(string email)
        {
            return _dbContext.Users.Where(t => t.Email == email).FirstOrDefault();
        }

        public void DeleteUser(string email)
        {
            User user = GetUserByName(email);
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
