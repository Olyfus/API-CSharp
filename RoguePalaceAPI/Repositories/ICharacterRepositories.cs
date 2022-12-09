using RoguePalaceAPI.Models;
using RoguePalaceAPI.Dto.Character;
namespace RoguePalaceAPI.Repositories
{
    public interface ICharacterRepositories
    {
        Character GetCharacterById(int id);
        List<Character> GetCharacter();
        void CreateCharacter(Character character);
        void UpdateCharacter(UpdateCharacterDto newCharacter, int oldCharacterId);
        void DeleteCharacter(int id);
    }
}
