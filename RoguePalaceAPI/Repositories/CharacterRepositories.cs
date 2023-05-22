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

        public Character GetById(int id)
        {
            return _context.Characters.Where(c => c.CharacterId == id).FirstOrDefault();
        }
        public List<Character> GetAll()
        {
            return _context.Characters.ToList();
        }
        public void Create(Character character)
        {
            _context.Characters.Add(character);
            _context.SaveChanges();
        }
        public void Update(UpdateCharacterDto newCharacter, int oldCharacterId)
        {
            //_context.Characters.Update()
        }
        public void Delete(int characterId)
        {
            Character character = GetById(characterId);
            _context.Characters.Remove(character);
            _context.SaveChanges();
        }
    }
}
