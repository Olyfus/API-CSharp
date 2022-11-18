using API1.Dto.Teacher;
using API1.Models;
namespace API1.Repositories
{
    public interface ITeacherRepositories
    {
        Teacher GetTeacherById(int id);
        List<Teacher> GetTeachers();
        void CreateTeacher(Teacher teacher);
        void UpdateTeacher(UpdateTeacherDto newTeacher, int oldTeacherId);
        void DeleteTeacher(int id);
    }
}
