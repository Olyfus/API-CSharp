using RoguePalaceAPI.Models;
using RoguePalaceAPI.Dto.Character;
namespace RoguePalaceAPI.Repositories
{
    public interface ICharacterRepositories
    {
        Character GetById(int id);
        List<Character> GetAll();
        void Create(Character character);
        void Update(UpdateCharacterDto newCharacter, int oldCharacterId);
        void Delete(int id);
    }
}
