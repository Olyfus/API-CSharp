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
        public List<Character> GetCharacter()
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

        }
        public void DeleteCharacter(int teacherId)
        {
            Character teacher = GetCharacterById(teacherId);
            _context.Characters.Remove(teacher);
            _context.SaveChanges();
        }
    }
}
