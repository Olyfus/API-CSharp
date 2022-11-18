using API1.DBContext;
using API1.Dto.Teacher;
using API1.Models;

namespace API1.Repositories
{
    public class TeacherRepositories : ITeacherRepositories
    {
        private readonly SchoolDBContext _context;

        public TeacherRepositories(SchoolDBContext context)
        {
            _context = context;
        }

        public Teacher GetTeacherById(int id)
        {
            return _context.Teachers.Where(t => t.TeacherId == id ).FirstOrDefault();
        }
        public void CreateTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);

            _context.SaveChanges();
        }
        public List<Teacher> GetTeachers()
        {
            return _context.Teachers.ToList();
        }

        public void UpdateTeacher(UpdateTeacherDto newTeacher, int oldTeacherId)
        {
            Teacher teacher = GetTeacherById(oldTeacherId);
            teacher.BirthDate = newTeacher.BirthDate;
            teacher.FirstName = newTeacher.FirstName;
            teacher.Name = newTeacher.Name;

            _context.Teachers.Update(teacher);
            _context.SaveChanges();
        }

        public void DeleteTeacher(int teacherId)
        {
            Teacher teacher = GetTeacherById(teacherId);
            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
        }
    }
}
