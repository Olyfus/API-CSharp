using RoguePalaceAPI.DBContext;
using RoguePalaceAPI.Dto.Groupe;
using RoguePalaceAPI.Models;

namespace RoguePalaceAPI.Repositories
{
    public class GroupeRepositories : IGroupeRepositories
    {
        private readonly RoguePalaceDBContext _context;
        public GroupeRepositories(RoguePalaceDBContext context)
        {
            _context = context;
        }

        public Groupe GetGroupeById(int id)
        {
        }
    }
}

            // return _context.Groupe.Where(g => g.GroupeId == id).FirstOrDefault();