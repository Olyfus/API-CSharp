using RoguePalaceAPI.DBContext;
using RoguePalaceAPI.Dto.Character;
using RoguePalaceAPI.Models;

namespace RoguePalaceAPI.Repositories
{
    public class CharacterRepositories : ICharacterRepositories
    {
        private readonly RoguePalaceDBContext _context;
        public CharacterRepositories(RoguePalaceDBContext context)
        {
            _context = context;
        }

        public Character GetCharacterById(int id)
        {
            return _context.Characters.Where(c => c.CharacterId == id).FirstOrDefault();
        }
        public List<Character> GetAllCharacter()
        {
            return _context.Characters.ToList();
        }
        public void CreateCharacter(Character character)
        {
            _context.Characters.Add(character);
            _context.SaveChanges();
        }
        public void UpdateCharacter(UpdateCharacterDto newCharacter, int oldCharacterId)
        {
            Character character = GetCharacterById(oldCharacterId);
            character.Level = newCharacter.Level;
            _context.Characters.Update(character);
            _context.SaveChanges();
        }
        public void DeleteCharacter(int characterId)
        {
            Character character = GetCharacterById(characterId);
            _context.Characters.Remove(character);
            _context.SaveChanges();
        }
    }
}
