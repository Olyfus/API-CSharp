using RoguePalaceAPI.Dto.User;
using RoguePalaceAPI.Models;

namespace RoguePalaceAPI.Repositories
{
    public interface IUserRepositories
    {
        List<User> GetUser();
        User GetUserByName(string email);
        void DeleteUser(string email);

    }
}
