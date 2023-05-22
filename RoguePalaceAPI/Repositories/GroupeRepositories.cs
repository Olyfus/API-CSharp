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
            return _context.Groupes.Where(g => g.GroupeId == id).FirstOrDefault();
        }

        public Groupe GetGroupeByName(string name)
        {
            return _context.Groupes.Where(g => g.Name == name).FirstOrDefault();
        }
        public List<Character> GetAllCharacterByGroupeName(string name)
        {
            var groupe = GetGroupeByName(name);
            return _context.Characters.ToList();
        }

        public List<Groupe> GetGroupes()
        {
            return _context.Groupes.ToList();
        }

        public void CreateGroupe(Groupe groupe)
        {

        }

        public void UpdateGroupe(UpdateGroupeDto newGroupe, int oldGroupeId )
        {

        }

        public void DeleteGroupe(int id)
        {

        }
    }
}

            // return _context.Groupe.Where(g => g.GroupeId == id).FirstOrDefault();