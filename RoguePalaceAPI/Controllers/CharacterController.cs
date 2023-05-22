using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoguePalaceAPI.Models;
using RoguePalaceAPI.Dto.Character;
using RoguePalaceAPI.Repositories;

namespace RoguePalaceAPI.Controllers
{

    [ApiController]
    [Route("character")]
    public class CharacterController : Controller
    {
        private readonly ICharacterRepositories _characterRepository;
        public CharacterController(ICharacterRepositories characterRepository)
        {
            _characterRepository = characterRepository;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult CreateCharacter(CreateCharacterDto characterDto)
        {
            Character character = new Character
            {

            };

            _characterRepository.Create(character);

            return Ok();
        }
        [Authorize]
        [HttpGet("{characterId}")]
        public ActionResult<Character> GetCharacterById(int characterId)
        {
            Character character = _characterRepository.GetById(characterId);
            if (character == null)
            {
                return NotFound();
            }
            return _characterRepository.GetById(characterId);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Character>> GetCharacter()
        {
            return Ok(_characterRepository.GetAll());
        }

        [HttpPut("{characterId}")]
        public ActionResult UpdateCharacter(UpdateCharacterDto characterDto, int characterId)
        {
            _characterRepository.Update(characterDto, characterId);

            return NoContent();
        }
        [HttpDelete("{characterId}")]
        public ActionResult DeleteCharacter(int characterId)
        {
            _characterRepository.Delete(characterId);
            return NoContent();
        }
    }
}
