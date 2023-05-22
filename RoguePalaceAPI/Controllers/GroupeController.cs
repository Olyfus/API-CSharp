using Microsoft.AspNetCore.Mvc;
using RoguePalaceAPI.Repositories;
using RoguePalaceAPI.Dto.Character;
using RoguePalaceAPI.Dto.Groupe;
using RoguePalaceAPI.Models;

namespace RoguePalaceAPI.Controllers
{
    public class GroupeController
    {
        [ApiController]
        [Route("groupe")]
        public class GroupeController : Controller
        {
            private readonly IGroupeRepositories _groupeRepositories;

            public GroupeController(IGroupeRepositories groupeRepositories)
            {
                _groupeRepositories = groupeRepositories;
            }

            [HttpPost]
            public ActionResult CreateGroupe(CreateGroupeDto groupeDto)
            {
                Groupe groupe = new Groupe
                {
                    Name = groupeDto.Name
                };
                _groupeRepositories.CreateGroupe(groupe);
                return Ok();
            }

            [HttpGet]
            public ActionResult<IEnumerable<Groupe>> GetGroupes()
            {
                return Ok(_groupeRepositories.GetGroupes());
            }

            [HttpGet("{groupeId}")]
            public ActionResult<Groupe> GetGroupeById(int groupeId)
            {
                Groupe groupe = _groupeRepositories.GetGroupeById(groupeId);
                if (groupe == null)
                {
                    return NotFound();
                }
                return _groupeRepositories.GetGroupeById(groupeId);
            }

            [HttpPut("{groupeId}")]
            public ActionResult UpdateGroupe(UpdateGroupeDto groupeDto, int groupeId)
            {
                _groupeRepositories.UpdateGroupe(groupeDto, groupeId);
                return NoContent();
            }

            [HttpDelete("{groupeId}")]
            public ActionResult DeleteGroupe(int groupeId)
            {
                _groupeRepositories.DeleteGroupe(groupeId);
                return NoContent();
            }
        }
    }
}
