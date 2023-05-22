using RoguePalaceAPI.DBContext;
using RoguePalaceAPI.Dto.Groupe;
using RoguePalaceAPI.Dto.Character;
using RoguePalaceAPI.Models;

namespace RoguePalaceAPI.Repositories
{
    public interface IGroupeRepositories
    {
        Groupe GetGroupeById(int id);
        Groupe GetGroupeByName(string name);
        List<Character> GetAllCharacterByGroupeName(string name);
        List<Groupe> GetGroupes();
        void CreateGroupe(Groupe groupe);
        void UpdateGroupe(UpdateGroupeDto newGroupe, int oldGroupeId);
        void DeleteGroupe(int id);

    }
}
