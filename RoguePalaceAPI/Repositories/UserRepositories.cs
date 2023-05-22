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

        public List<User> GetUser()
        {
            return _dbContext.User.ToList();
        }

        public User GetUserByName(string email)
        {
            return _dbContext.User.Where(t => t.Email == email).FirstOrDefault();
        }

        public void DeleteUser(string email)
        {
            User user = GetUserByName(email);
            _dbContext.User.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
