using API1.Dto.Subject;
using API1.Models;
using API1.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace API1.Controllers
{
    [ApiController]
    [Route("subject")]
    public class SubjectController : Controller
    {

        private readonly ISubjectRepositories _subjectRepository;
        public SubjectController(ISubjectRepositories subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        [HttpPost]
        public ActionResult CreateSubject(CreateSubjectDto subjectDto)
        {
            Subject subject = new Subject
            {
                Name = subjectDto.name
            };
            _subjectRepository.CreateSubject(subject);
            return Ok();
        }

        [HttpGet("{subjectId}")]
        public ActionResult<Subject> GetSubjectById(int subjectId)
        {
            Subject subject = _subjectRepository.GetSubjectById(subjectId);
            if (subject == null)
            {
                return NotFound();
            }
            return _subjectRepository.GetSubjectById(subjectId);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Subject>> GetSubject()
        {
            return Ok(_subjectRepository.GetSubjects());
        }

        [HttpPut("{subjectId}")]
        public ActionResult UpdateSubject(UpdateSubjectDto subjectDto, int subjectID)
        {
            _subjectRepository.UpdateSubject(subjectDto, subjectID);
            return NoContent();
        }

        [HttpDelete("{subjectId}")]
        public ActionResult DeleteSubject(int subjectId)
        {
            _subjectRepository.DeleteSubject(subjectId);
            return NoContent();
        }
    }
}
