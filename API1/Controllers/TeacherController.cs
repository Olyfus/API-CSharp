using API1.Dto.Teacher;
using API1.Models;
using API1.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers
{
    [ApiController]
    [Route("teachers")]
    public class TeacherController : Controller
    {
        private readonly ITeacherRepositories _teacherRepository;
        public TeacherController(ITeacherRepositories teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        [HttpPost]
        public ActionResult CreateTeacher(CreateTeacherDto teacherDto)
        {
            Teacher teacher = new Teacher
            {
                BirthDate = teacherDto.BirthDate,
                FirstName = teacherDto.FirstName,
                Name = teacherDto.Name
            };

            _teacherRepository.CreateTeacher(teacher);

            return Ok();
        }

        [HttpGet("{teacherId}")]
        public ActionResult<Teacher> GetTeacherById(int teacherId)
        {
            Teacher teacher = _teacherRepository.GetTeacherById(teacherId);
            if (teacher == null)
            {
                return NotFound();
            }
            return _teacherRepository.GetTeacherById(teacherId);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Teacher>> GetTeachers()
        {
            return Ok(_teacherRepository.GetTeachers());
        }

        [HttpPut("{teacherId}")]
        public ActionResult UpdateTeacher(UpdateTeacherDto teacherDto, int teacherId)
        {
            _teacherRepository.UpdateTeacher(teacherDto, teacherId);

            return NoContent();
        }
        [HttpDelete("{teacherId}")]
        public ActionResult DeleteTeacher(int teacherId)
        {
            _teacherRepository.DeleteTeacher(teacherId);
            return NoContent();
        }
    }
}
